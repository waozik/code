import requests
import re
import threading
import queue
from time import sleep
from random import randint
origin_url = 'http://www.kuaidaili.com/free/intr/'


class Proxy:
    url = ''
    page = 0
    html = queue.Queue()
    ip = queue.Queue()
    userful_ip = []

    def __init__(self, url, page):
        while(url.endswith('/')):
            url = url[:-1]
        self.url = url
        self.page = page
        self.html = queue.Queue()

    def get_html(self, page):
        '''
        获取页面html
        '''
        
        str_url = '{0}/{1}'.format(self.url, page+1)
        response = requests.get(str_url)
        response.encoding = 'utf-8'
        html = response.text
       # print(html)
        self.html.put(html)

    def re_html(self):
        '''
        解析ip
        '''
        for i in range(self.page):
            str_html = self.html.get_nowait()
            #获取tbody部分
            ip_original_list_boy = re.findall(
                r'<tbody>(.*?)</tbody>', str_html, re.DOTALL | re.I)           
            if ip_original_list_boy:  
                ip_original_tr = re.findall(
                    r'<tr.*?>.*?</tr>', ip_original_list_boy[0], re.I | re.DOTALL)
                for ip in ip_original_tr:
                    ip_original = re.findall(
                        r'<td.*?>(.*?)</td>', ip, re.I | re.DOTALL)[0:5]
                    del ip_original[2]
                    self.ip.put(tuple(ip_original))
                    


    def get_ip(self):
        '''
        筛选ip
        '''
        validation_ip = self.ip.get() 
        proxy = '{0}:{1}'.format(validation_ip[0] ,validation_ip[1])
        proxies = {'http':proxy,'https':proxy}
        try:
            requests.head('http://www.qq.com/',proxies = proxies,timeout=1.5)
        except BaseException:
            print(proxy+'此代理无效'+'\n')
        else:
            self.userful_ip.append(validation_ip)
            print(proxy+'\n')
        

# def _main():
#     proxy_free = Proxy(origin_url, 5)
#     threads = []
#     page = proxy_free.page
#     # 创建线程
#     for p in range(page):
#         t = threading.Thread(target=proxy_free.get_html,
#                              args=(p + 1,))
#         threads.append(t)
#     # 开始线程
#     for t in range(page):
#         threads[t].start()
#     # 阻塞线程
#     for t in range(page):
#         threads[t].join()
#     print(proxy_free.html.qsize())
#     proxy_free.re_html()
def _main():
    proxy_free = Proxy(origin_url, 5)
    for g in range(5):
        proxy_free.get_html(g)
        sleep(2)
    proxy_free.re_html()

    threads = []
    for i in range(75):
        t = threading.Thread(target=proxy_free.get_ip)
        threads.append(t)
    for t in range(75):
        threads[t].start()
    for t in range(75):
        threads[t].join()

    print(len(proxy_free.userful_ip))
    





if(__name__ == '__main__'):
    _main()
