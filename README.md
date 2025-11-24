# WeatherApp 🌦️

A simple **C# WPF desktop application** for monitoring current weather with the ability to pin favorite cities.

---

## ✨ Features
- 🔍 Search for a city and view its current weather
- 📌 Pin cities to keep them in a dedicated list
- 💾 Save pinned cities to a local file (`pinned.txt`)
- 🔄 Automatically reload pinned cities on startup
- 🖥️ Clean MVVM architecture with data binding and commands

---

## ⚙️ Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/<your-username>/WeatherApp.git
   Open the solution in Visual Studio.

  Restore NuGet packages if required.
  Insert your own API key in WeatherService.cs:
  private readonly string _apiKey = "Insert_Your_API_Key_Here";
