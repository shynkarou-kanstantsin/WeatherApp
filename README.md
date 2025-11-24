# WeatherApp 🌦️

**C# WPF desktop application** for monitoring current weather with the ability to pin favorite cities.

---

## ✨ Features
- 🔍 Search for a city and view its current weather
- 📌 Pin cities to keep them in a dedicated list
- 🌐 Fetches live weather data using OpenWeatherMap API via HttpClient
- 💾 Save pinned cities to a local file (`pinned.txt`)
- 🔄 Automatically reload pinned cities on startup
- 🖥️ Clean MVVM architecture with data binding and commands

---

## 🧰 Tech Stack
- C# 10
- .NET 8
- WPF (Windows Presentation Foundation)
- MVVM (Model-View-ViewModel)
- OpenWeatherMap API
- HttpClient for RESTful API integration

---

## 📸 Screenshots

### 🔹 Main Interface
Shows pinned cities and current weather search.

<img width="1017" height="579" alt="Weather" src="https://github.com/user-attachments/assets/de4ef1d9-7f25-4386-baea-4ee477661859" />

---

## ⚙️ Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/<your-username>/WeatherApp.git
   Open the solution in Visual Studio.
  
  Restore NuGet packages if required.

  This app uses [OpenWeatherMap](https://openweathermap.org/api) to fetch live weather data.  
  You need to register and insert your API key in `WeatherService.cs`.
  Insert your own API key in WeatherService.cs:
  
  private readonly string _apiKey = "Insert_Your_API_Key_Here";

---

  ## 🗺️ Roadmap
- [x] Search city and display weather
- [x] Pin cities and persist them
- [ ] Add weather icons based on condition
- [ ] Improve UI styling and animations
- [ ] Add daily/weekly forecast

