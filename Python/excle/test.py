import os
import xlrd
import xlwt
import urllib
import urllib.request
import re
import json


def check_patah():
    '切换路径到桌面'
    username = os.getlogin()
    path = 'c:\\Users\\%s\\desktop' % username
    os.chdir(path)


def read_exc():
    '返回用户id  List类型'
    workbook = xlrd.open_workbook('用户数据2.xlsx')
    sheet1 = workbook.sheets()[0]
    id_list = sheet1.col_values(0)
    id_list = id_list[1:]
    return id_list


def get_name(id_list):
    name_list = []
    for customer_id in id_list:
        url = 'http://passport.aliqq.cc/api/customer/get/%s' % int(customer_id)
        req = urllib.request.Request(url)
        customerInfo = urllib.request.urlopen(req).read().decode('utf-8')
        json_name = json.loads(customerInfo)
        name=json_name["FirstName"]
        print(name)

        # reg = r'"FirstName":"(.+?)"'
        #name = re.search(reg,customerInfo).group(1)
        name_list.append(name)
    return name_list


def write_exc(id_list, name_list):
    '写数据'
    workbook = xlwt.Workbook()
    sheet = workbook.add_sheet('Sheet 1')
    for i in range(len(id_list)):
        if(i == 0):
            sheet.write(i, 0, '用户Id')
            sheet.write(i, 1, '姓名')
        else:
            sheet.write(i, 0, id_list[i - 1])
            sheet.write(i, 1, name_list[i - 1])
    workbook.save('用户数据123.xls')


def main():
    check_patah()
    id_list = read_exc()
    name_list = get_name(id_list)
    write_exc(id_list, name_list)


if __name__ == '__main__':
    main()
