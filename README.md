# WinCeExample
This .NET CF 3.5 / C# Windows CE / Windows Mobile 6.5 example application and setting up the environment

Этот проект  показывает мою боль и страдания. Сэкономлю время тем людям, кто захочет разработать приложение на .net compact 3.5.

1. Понадобится : Visual Studio 2008 team system. Windows Server 2008 R2 или Windows 7. 
В Windows Serrver 2008 r2 установить поддержку .net compact framawokr 3.5. (.Net framework 3.5.1 Features)
Virtual PC 2007. https://www.microsoft.com/en-us/download/details.aspx?id=4580
Windows ce 6 plantform sdk
https://www.microsoft.com/en-us/download/details.aspx?id=6135

Для удобства использование и написания тестов.
Resharper версии 7. Я использовал 7.1.3000. В случае с решарпером, можно писать тесты на NUnit. MsTest - это полная дичь, я так считаю.

5. Использование SQLite3
https://www.sqlitetutorial.net/download-install-sqlite/
Установить ide sqliteStudio
https://github.com/pawelsalawa/sqlitestudio
Самое главное скачать версию SQLite-1.0.66.0. Добавить в Reference System.data.SQLLite и в корень проекта SQLite.Interop.066.DLL,
именно в корень, для того чтобы файл попал в сборку. Установить в проекте для SQLite.Interop.066.DLL - Properties - Build "Content" и Copy to Output Directory "Copy if newer".

Установка сторонних dll.
Скачать из nuget библиотеку, найти там папку netCF35(если такая имеется), перебросить в папку Packages папку с библиотекой.
Если в скачанной библиотеке нету папки netCF35 - либо библиотека не имеет поддержки .net framework 3.5(compact framework), либо библиотека слишком поздней версии.
Указать в Reference .dll из папки netCF35
Нагета в Visual Studio 2008 нету, можно через консоль скачивать через nuget, но там нету описания, в какой версиии библиотеки есть netCF3.5

Установка WinServer 2008 на HyperV
Если вы пошли по этому варианту, то Virtual PC работать не будет.
Даже если в эмуляторе установить "File" - "Configure" - "Network" - "Enable NE2000 PCMCIA" - галочку, интернета не будет.
Обходной вариант. Ставим windows mobile device center https://support.microsoft.com/en-us/help/931937/description-of-windows-mobile-device-center
Ранее это был Active Sync потом он перерос в WMDC. 
Запуск:
- Visual Studio 2008 - Tools - Device Emulator Manager 
Находим нужный нам эмулятор, допустим это буудет Windows Mobile 5 Classic Emulator 
Right Click - Connect 
Ждем пока устройство запустится
Через пуск находим зелененький значок windows mobile device center, запускаем его
Как устройство запустилось, переходим в окно Device Emulator Manage - выбираем Windows Mobile 5 Classic Emulator  - правой кнопкой "Cradle"
В windows mobile device center устройство присоединиться, в настройках надо указать DMA и "The Internet connection"
Проверить интернет можно в Internet Exprorer.
В случае если у вам не идет подключение к WMDC - вы используете удаленный рабочий стол для подключения к виртуалке.

Если вы установили все на старый комп без виртуалок, вам будет достаточно Virtual PC и  галочики в настройках эмулятора "File" - "Configure" - "Network" - "Enable NE2000 PCMCIA"

.net compact framework 3.5
-отсутствует нормальная Linq, даже если подключить System.Core.dll - версии .net 3.5 он напишет, что не может работать с версией 2.0.0.
- tsl 1.2 нету, приходится поль


