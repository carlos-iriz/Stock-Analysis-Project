# Stock-Analysis-Project
Given a CSV file with stock information the program will display and analyze stock data

VERSION 1:

Applied Visual Studio to build a Windows Forms Application that uses data binding, file handling, and dynamic chart manipulation to successfully load, display, and update stock data to user given a specified date range

Application loads stock data from yahoo finance and displays stock information by placing data into a list of candlestick objects that is fed into a chart object

VERSION 2:

Added SmartCandlestick class which is derived from the original candlestick class. SmartCandlestick adds properties that are calculated from the base candlestick values. SmartCandlestick also creates a dictionary within the class that saves what type of pattern a specific candlestick is. The dictionary is initially empty within the class
which allows for someone to pull from the SmartCandlestick class without having to change it at all, any patterns that are calculated can be done within whatever program
the user of the class writes, they can simply add the patterns they wish to calcuated to the dictionary from a created SmartCandlestick.

The form was also changed so that a user can select more than one set of candlestick data to display for a given date range. The form can also take in data using SmartCandlesticks. Originally, the form displayed data using a list of candlesticks that was bound to a specific date range, this was not changed when using SmartCandlesticks
for this iteration of the project. The form still uses a list of candlesticks but the list is instead populated with objects of the SmartCandlestick class instead of candlestick.
This simple change meant we did not have to change much of version 1's code since we took advantage of polymorphism, since a SmartCandlestick is still technically a candlestick
we were able to fill a list of candlesticks with SmartCandlesticks. The implementation of SmartCandlesticks allowed for us to display all the patterns within the dictionary
of a given SmartCandlestick to the user in the form of a ComboBox. Upon loading a stock, the form automatically calculates a set of 8 patterns and displays to the user. 
Upon selecting a specific pattern in the ComboBox, the form will display an arrow pointing each of the displayed candlesticks that match the selected pattern.
