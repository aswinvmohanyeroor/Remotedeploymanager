# RemoteDeployManager

RemoteDeployManager is a C# console application designed to help automate the deployment of files from one Windows machine to another over a network using standard protocols like SMB. It is ideal for IT administrators who need to copy files to multiple target systems using Windows credentials without relying on remote desktop sessions.

## 🚀 Features

- Copy files to remote Windows PCs over the network
- Authenticate using Windows username and password
- Designed to be run via command line or scripts
- Useful for deployment automation or internal IT operations

## 📂 Folder Structure

RemoteDeployManager/
│
├── RemoteDeployManager.sln         # Visual Studio Solution
├── RemoteDeployManager.csproj      # C# Project File
└── Program.cs                      # Main application logic

## 🛠️ Requirements

- Windows OS (tested on Windows 10/11)
- .NET 6.0 or later
- Network share access enabled on target machine(s)
- Shared folders accessible via UNC path (\\PC\ShareName)

## 🧑‍💻 Usage

1. Configure the target share on the remote PC.
2. Run the app from command line / run the exe directly
3. The application will attempt to connect, authenticate, and copy the file.

## 🔐 Security Notes

- Credentials are passed via parameters, which may be visible in history. Use with caution.
- Consider using secure credential storage or prompt-based input for sensitive environments.

## 📦 Future Enhancements (Planned)

- Encrypt password input
- Log deployment results to file
- Support batch file transfers
- Retry mechanism for failed copies



**Author:** Veen 

