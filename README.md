# Diacritic Buster #

This program can help you get rid of incompatible characters found in any piece of text using their alternative or simplified forms instead to be processable by any target reading software that is simply not able to deal with their original equivalents. It was written in C# and uses Window Forms as the user interface. Runs in 32- or 64-bit mode depending on the system environment.

### Handling the program ###

Diacritic Buster is simple to use – just copy and paste the text to be converted onto the "Initial text" field (use the Ctrl+V combination or press the right mouse button on the text box and select "Paste" from the context menu) and click on "Convert". The final text will appear to the right. To copy the whole text, press the right mouse button on the field and choose "Select All" from the menu and then, click the same button on the same area and select the "Copy" command. Now you can go back to your favourite text editor or somewhere else and continue your work right after pasting the fixed piece of your text.

If there are chars that you would like to remain intact, you can use a so-called scheme file that is suitable for your needs – only the characters mentioned in such a file will be remade.

### Program options ###

Diacritic Buster allows to change the following settings: 

* Convert Clipboard content automatically with the Alt+C hotkey combination – until there is a text inside the system Clipboard, it can be converted using currently chosen scheme. This allows you to use the program without having to switch between applications.

* Program hidden on start-up – after start-up, the program is hidden in the system tray. To restore it, one needs to double-click the left mouse button on the program's icon or press the right mouse button and from the context menu, select "Hide/restore".

* Available schemes – the list of schemes you are able to use. The following ones are originally included with the program, thus they are ready to use: Alternate German accents, Convert Romaji text to Katakana, Make Hungarian compatible with Western European set, Remove all Central European specific accents only, Remove Polish accents except o-acute, Remove Polish accents, Romanise Katakana letters, Romanise Russian letters the GOST 2002(B) method.

When the scheme is set to default, the program will try to handle all present diacritics its own way. To add another custom scheme to the list, you will need to create a new plain text document (i.e. a text file written in a simple text editor like Windows Notepad, gedit or vi that lacks of any formatting feature) and necessarily, save it with extension ".txt" in UTF-8 character encoding. A potential Diacritic Buster scheme file needs to consist solely of the lines that use the following pattern: "the_char_or_string_to_be_swapped|the_target_char_or_string" (without quotes). If there is something wrong with the import file, it will not be accepted, however transforming symbols (except the char '|') into any other characters is also possible. To make work with digraphs and longer combinations fully possible, it is required to sort descending all the keys in the scheme file starting from the longest key(s) (consisting of the highest amount of characters) to the shortest ones (consisting of only one character).

### Recommended IDE ###

Visual Studio 2012 due to the ability to handle .NET Framework 2.0 and its newer versions.

### Program licence ###

Please refer to the LICENSE.txt file of this repository for more information regarding it.