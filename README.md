# Serial to Keyboard (.NET Core)

This is a simple .NET Core Windows Forms app that does a cool trick - it turns data from COM ports into keyboard inputs.

Originally, it was made to read data from an Elgin DP-15 Plus digital weighing scale. But, if you have some other RS232 device you want to get data from, just tweak the [DefaultFormatter.cs](Control/DefaultFormatter.cs) class to make it work for you.

Quick heads up, though - this app is Windows-only. If you're feeling adventurous and want to make it work on other operating systems, you're welcome to jump in and contribute some code. Just open a pull request (PR) to make it even better!

## Disclaimer

I'm not a C# pro, and this is my first stab at a Windows Forms app. So, if the code looks a bit wonky, that's why.

Big shoutout to [JeanPaulBeard](https://github.com/JeanPaulBeard) for the code. I borrowed most of it from the [Serial-to-keyboard](https://github.com/JeanPaulBeard/Serial-to-keyboard) repo.

## Requirements

- .NET Core 8 or newer (SDK)

## Running the project

To get this thing going, throw these commands in your terminal:

```sh
dotnet build
dotnet run
```