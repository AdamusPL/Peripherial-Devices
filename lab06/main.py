# importing the os library
import os
import socket
import threading


def enable_wifi_card():  # turn on device
    os.system("netsh interface set interface Wi-Fi enable")
    print("Wi-Fi turned on")


def disable_wifi_card():  # turn off device
    os.system("netsh interface set interface Wi-Fi disable")
    print("Wi-Fi turned off")


def display_networks():  # connect with selected network
    os.system('cmd /c "netsh wlan show networks"')
    # aby połączyć należy podać nazwę sieci
    router_name = input('Give Name/SSID of network which you want to connect: ')
    # łączenie z wybraną siecią
    os.system(f'''cmd /c "netsh wlan connect name = {router_name}"''')


def ping(ip):  # function which makes ping
    os.system('cmd /c "ping "' + ip)


def send_file(filename, host='hostname', port=50000):  # send file
    s = socket.socket()
    s.connect((host, port))

    with open(filename, 'rb') as f:
        data = f.read(1024)
        while data:
            s.send(data)
            data = f.read(1024)

    s.close()
    print("File was sent.")


def handle_client_connection(client_socket):  # receive sent file
    try:
        filename = "test.txt"
        with open(filename, 'wb') as f:
            while True:
                data = client_socket.recv(1024)
                if not data:
                    break
                f.write(data)
                print(f"Received: {data.decode()}")
                client_socket.send("Echo: ".encode() + data)
    finally:
        client_socket.close()


def start_server(host,
                 port=50000):  # method accepting connection and creating thread handling connection with client
    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server.bind((host, port))
    server.listen(5)
    print(f"Server is listening on: {host}:{port}")

    def listen(server):
        while True:
            client_sock, address = server.accept()
            print(f"Accepted connection from: {address}")
            client_handler = threading.Thread(
                target=handle_client_connection,
                args=(client_sock,)
            )
            client_handler.start()

    t = threading.Thread(target=listen, args=(server,))
    t.start()


def run_Server():  # method which starts thread listening on specific port which accepts connection
    my_ip = get_local_ip()
    server_thread = threading.Thread(target=start_server(my_ip, 50000, ))
    server_thread.start()


def get_local_ip():  # printing IP address of device
    s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    try:
        # doesn't even have to be reachable
        s.connect(('10.255.255.255', 1))
        IP = s.getsockname()[0]
    except:
        IP = '127.0.0.1'
    finally:
        s.close()
    return IP


print(get_local_ip())


def main():
    my_ip = get_local_ip()
    start_server(my_ip)
    option = 0
    while True:

        print("1. Connect to Wi-Fi network")
        print("2. Send file")
        print("3. Ping")
        print("4. Turn on Wi-Fi")
        print("5. Turn off Wi-fi")
        print("0. Exit")
        option = input("Enter option\n")

        if option.__eq__("1"):
            display_networks()

        elif option.__eq__("2"):
            filename = input("Give the file name")
            hostname = input("Give the hostname")
            send_file(filename, hostname)

        elif option.__eq__("0"):
            return
        elif option.__eq__("3"):
            ip = input("Give IP:")
            ping(ip)
        elif option.__eq__("4"):
            enable_wifi_card()
        elif option.__eq__("5"):
            disable_wifi_card()


if __name__ == '__main__':
    main()
