# importing the os library
import os
import socket
import threading


def enable_wifi_card():         #włączenie urządzenia
    os.system("netsh interface set interface Wi-Fi enable")
    print("Wlaczono wifi")


def disable_wifi_card():        #wyłączenie urządzenia
    os.system("netsh interface set interface Wi-Fi disable")
    print("Wylaczono wifi")


def display_networks():         #połączenie z wybraną siecią
    os.system('cmd /c "netsh wlan show networks"')
    # aby połączyć należy podać nazwę sieci
    router_name = input('Podaj Name/SSID sieci z ktora chcesz sie polaczyc: ')
    # łączenie z wybraną siecią
    os.system(f'''cmd /c "netsh wlan connect name = {router_name}"''')


def ping(ip):                   #funkcja umożliwia ping
    os.system('cmd /c "ping "'+ip)

def send_file(filename, host='hostname', port=50000):   #przesłanie pliku
    s = socket.socket()
    s.connect((host, port))

    with open(filename, 'rb') as f:
        data = f.read(1024)
        while data:
            s.send(data)
            data = f.read(1024)

    s.close()
    print("Plik został wysłany.")


def handle_client_connection(client_socket):  #odebranie przesłanego pliku
    try:
        filename = "test.txt"
        with open(filename, 'wb') as f:
            while True:
                data = client_socket.recv(1024)
                if not data:
                    break
                f.write(data)
                print(f"Otrzymano: {data.decode()}")
                client_socket.send("Echo: ".encode() + data)
    finally:
        client_socket.close()


def start_server(host, port=50000):         #metoda akceptująca połączenie oraz tworząca wątek obsługujący połączenie z klientem
    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server.bind((host, port))
    server.listen(5)
    print(f"Serwer nasłuchuje na {host}:{port}")
    def listen(server):
        while True:
            client_sock, address = server.accept()
            print(f"Akceptacja połączenia od {address}")
            client_handler = threading.Thread(
                target=handle_client_connection,
                args=(client_sock,)
            )
            client_handler.start()
    t = threading.Thread(target=listen, args = (server,))
    t.start()



def run_Server():                #metoda uruchamia wątek nasłuchujący na danym porcie, który akceptuje połączenia
    my_ip = get_local_ip()
    server_thread = threading.Thread(target=start_server(my_ip,50000,))
    server_thread.start()

def get_local_ip():             #wyświetlenie adresu ip urządzenia
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

        print("1.Connect to Wi-Fi network")
        print("2.Send file")
        print("3.Ping")
        print("4.Wlacz WiFi")
        print("5.Wylacz Wifi")
        print("0.Wyjdz")
        option = input("Enter option\n")


        if option.__eq__("1"):
            display_networks()

        elif option.__eq__("2"):
            filename = input("Give file name")
            hostname = input("Give hostname")
            send_file(filename, hostname)

        elif option.__eq__("0"):
            return
        elif option.__eq__("3"):
            ip = input("Give ip:")
            ping(ip)
        elif option.__eq__("4"):
            enable_wifi_card()
        elif option.__eq__("5"):
            disable_wifi_card()


if __name__ == '__main__':
    main()