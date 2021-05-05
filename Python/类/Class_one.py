class Student(object):
    count = 0
    books = []

    def __init__(self, name, age):
        self.name = name
        self.age = age


def a():
    Student.hobbies = ['reading', 'jogging', 'swimming']
    print(dir(Student))


def b():
    print(dir(Student))


def main():
    print(Student.__name__ )
  
    print(Student.__bases__ )
    print('\n')
    
if __name__ == '__main__':
    main()
