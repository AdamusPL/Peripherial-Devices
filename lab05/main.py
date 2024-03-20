# This is a sample Python script.

# Press Shift+F10 to execute it or replace it with your code.
# Press Double Shift to search everywhere for classes, files, tool windows, actions, and settings.


import time
import serial
import threading
from xmodem import XMODEM


def main():
    def read_from_port(port):
        while True:
            data = port.read()
            if data:
                try:
                    print(data.decode('utf-8'), end='')
                except UnicodeDecodeError:
                    print(data, end='')

    def getc(size, timeout=50):
        return modem_port.read(size) or None

    def putc(data, timeout=50):
        modem_port.write(data)
        time.sleep(0.1)

    modem_port = serial.Serial(port='COM1', bytesize=8, baudrate=9600, parity=serial.PARITY_NONE,
                               stopbits=serial.STOPBITS_ONE, rtscts=True)
    print('Port is open\n')

    # Start the listening thread
    t = threading.Thread(target=read_from_port, daemon=True, args=(modem_port,))
    print('Thread started')
    t.start()

    # Initialize XMODEM protocol
    modem = XMODEM(getc, putc)

    # Main program loop
    while True:

        message = input("->")

        if message == 'exit':
            modem_port.close()
            break
        elif message == 'send':
            filename = input("File: ")
            with open(filename, 'rb') as file_to_send:
                modem.send(file_to_send)
            print("File sent.")
        elif message == 'receive':
            filename = input("Save file as: ")
            with open(filename, 'wb') as file_to_receive:
                modem.recv(file_to_receive)
            print("Received file")
        elif message == "call":
            modem_port.write(("ATD" + '\r\n').encode('utf-8'))
        elif message == "answer":
            modem_port.write(("ATA" + '\r\n').encode('utf-8'))
        elif message == "reject":
            modem_port.write(("ATH" + '\r\n').encode('utf-8'))
        elif message == "at":
            modem_port.write(("AT" + '\r\n').encode('utf-8'))
        else:
            modem_port.write((message + '\r\n').encode('utf-8'))


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    main()

# See PyCharm help at https://www.jetbrains.com/help/pycharm/
