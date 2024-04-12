#mPythonType:0
from mpython import *

import network

my_wifi = wifi()

my_wifi.connectWiFi("my_wifi", "WanWuHuLian")

import time

from siot import iot

_siot_connected = False

_siot_topic_list = []
def _siot_callback_1(_):pass
def _siot_callback_2(_):pass
def _siot_callback_3(_):pass
def _siot_callback_4(_):pass
def _siot_callback_5(_):pass
def _siot_callback(_siot_topic, _siot_msg):
    global __msg
    _siot_topic = str(_siot_topic, "utf-8")
    __msg = str(_siot_msg, "utf-8")
    if _siot_topic in _siot_topic_list:
        eval('_siot_recv_' + bytes.decode(ubinascii.hexlify(_siot_topic)) + '(__msg)')
    if _siot_topic == _topic_1: return _siot_callback_1(__msg)
    elif _siot_topic == _topic_2: return _siot_callback_2(__msg)
    elif _siot_topic == _topic_3: return _siot_callback_3(__msg)
    elif _siot_topic == _topic_4: return _siot_callback_4(__msg)
    elif _siot_topic == _topic_5: return _siot_callback_5(__msg)

_topic_1 = 'WeatherStation/WenDu'
_topic_2 = 'WeatherStation/Shidu'
_topic_3 = 'WeatherStation/FengSu'
_topic_4 = 'WeatherStation/QiYa'
_topic_5 = ""

from machine import UART

uart1 = UART(1, baudrate=9600, tx=Pin.P16, rx=Pin.P15)

loopStartTime = None

from bluebit import *

wd = None

sd = None

fs = None

qy = None

fsDec = None

fsHexH = None

fsHexL = None

def GetFs():
    global Line1, Line2, Line3, Line4, fsDec, fsList, fsHexH, fsHexL, loopStartTime, wd, sd, fs, qy
    uart1.write(bytes([0x02, 0x03, 0x00,0x00,0x00,0x01,0x84,0x39]))
    time.sleep_ms(100)
    fsDec = -1
    if uart1.any():
        fsList = uart1.read()
        fsHexH = fsList[3]
        fsHexL = fsList[4]
        fsDec = fsHexL + fsHexH * 256
        fsDec = fsDec / 10
    return fsDec

def Display(Line1, Line2, Line3, Line4):
    global fsDec, fsList, fsHexH, fsHexL, loopStartTime, wd, sd, fs, qy
    oled.fill(0)
    oled.DispChar(str(Line1), 0, 0, 1)
    oled.DispChar(str(Line2), 0, 16, 1)
    oled.DispChar(str(Line3), 0, 32, 1)
    oled.DispChar(str(Line4), 0, 48, 1)
    oled.show()

sht20 = SHT20()

delveBit_pressure_0 = DelveBit(0X5C)
Display(' ------在线气象站------', '', '初始化网络连接......', '')
time.sleep(5)
Display(' ------在线气象站------', '', '连接MQTT服务器......', '')
_siot = iot('WeatherStation', 'mqtt.hebeav.com', user='siot', password='dfrobot')
_siot.set_callback(_siot_callback)
try:
    _siot.connect()
    _siot_connected = True
except OSError as err:
    print("OSError: {}".format(err))
time.sleep(5)
# 订阅主题才能保持MQTT到服务器的连接。
_siot.getsubscribe('WeatherStation/WenDu')
_siot.getsubscribe('WeatherStation/Shidu')
_siot.getsubscribe('WeatherStation/FengSu')
_siot.getsubscribe('WeatherStation/QiYa')
_siot.loop()
while True:
    loopStartTime = time.ticks_us()
    wd = round(sht20.temperature(), 2)
    sd = round(sht20.humidity(), 2)
    fs = round((GetFs()), 2)
    qy = delveBit_pressure_0.common_measure()
    # 用发送消息到主题1的方式引发错误，mPython的模块代码存在错误！
    _siot.publish(str('WeatherStation/WenDu'), str(wd).encode("utf-8"))
    # 用发送消息到主题1的方式引发错误，mPython的模块代码存在错误！
    _siot.publish(str('WeatherStation/ShiDu'), str(sd).encode("utf-8"))
    # 用发送消息到主题1的方式引发错误，mPython的模块代码存在错误！
    _siot.publish(str('WeatherStation/FengSu'), str(fs).encode("utf-8"))
    # 用发送消息到主题1的方式引发错误，mPython的模块代码存在错误！
    _siot.publish(str('WeatherStation/QiYa'), str(qy).encode("utf-8"))
    Display(str('温度：') + str(str(wd) + str(' ℃')), str('湿度：') + str(str(sd) + str(' %')), str('风速：') + str(str(fs) + str(' m/s')), str('气压：') + str(str(qy) + str('Pa')))
    time.sleep_us((60000000 - time.ticks_diff(time.ticks_us(), loopStartTime)))
