import os
import re
import urllib.request


def mkfolder(fold_name):
    '在桌面个创建一个文件夹'
    login_user = os.getlogin()
    des = 'c:/Users/%s/desktop' % login_user
    if os.path.isdir(fold_name):
        os.chdir(fold_name)
    else:
        os.mkdir(des)


def get_source(url):
    '获取url地址的资源'
    req = urllib.request.Request(url)
    source = urllib.request.urlopen(req)
    return source


def get_page(url):
    '获取页面html'
    html_source = get_source(url)
    return html_source


def find_images():
    '获取页面的图片链接'
    r = r'data-original="((http:.*?)(gif|png|jpeg|jpg))!'
    adress = []
    for a in range(1, 11):
        new_url = 'http://588ku.com/beijing/0-0-pxnum-0-%s' % a
        html_code = get_page(new_url).read().decode('utf-8')
        ad = re.findall(r, html_code)
        adress.extend(ad)
    return adress


def save_image():
    '储存图片'
    for image_adr in find_images():
        file_name = image_adr[0].split('/')[-1]
        source = get_source(image_adr[0]).read()
        with open(file_name, 'wb') as f:
            f.write(source)


def main():
    '执行代码片段'
    mkfolder('img_download')
    find_images()
    save_image()


if __name__ == '__main__':
    main()
