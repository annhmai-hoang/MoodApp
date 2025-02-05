# MoodApp

MoodApp is a simple wellness application that helps users track their daily moods, provides personalized affirmation messages and enter short journal entries. The app categorizes moods into three categories: Positive, Neutral, and Negative, and visualizes the data in a pie chart. Additionally, users can view their past mood/journal logs in a table format with pagination.

## Features
* Mood Tracking: Log your mood for each day as Positive, Neutral, or Negative.
* Affirmation Messages: Receive personalized affirmation messages based on your mood.
* Mood Visualization: See a pie chart of your mood distribution for the week.
* Past Mood Logs: View past mood entries with easy navigation through paginated tables.
 
## Technologies Used
* C# and .NET for application development.
* SQLite for local database management.
* Windows Form for user interface and routing.

## Requirements
* Windows OS (for running the installer)
* .NET 6.0 or later (for running the application)
* SQLite for database storage
* Visual Studio (recommended for development and debugging)

## Installation
1. **Clone the repository**:
   ```bash
   git clone https://github.com/annhmai-hoang/MoodApp.git
   ```
2. **Open the installer**: `MoodApp.msi`.
3. **Run the installer**: Double-click the installer file and follow the on-screen instructions.
4. **Launch the application**: After installation, you can open MoodApp from the Start Menu.

## Usage
1. **Open the app**: Once opened, you will be prompted to log in. Remember to create a new account if this is your first time logging in.
2. **Log your mood**: Choose from the drop-down menu to record how you feel.
3. **View your pie chart**: Your weekly mood data will be visualized in a pie chart.
4. **Check past logs**: Navigate through your previous mood/journal logs using the table and pagination controls.
5. **Enter short notes in Journal Entries**: Jot down your thought for the moment.
6. **Try out all the buttons**: There is a fun button with an embedded surprise.

## (Optional) Build and run the project in Visual Studio
1. **Open [Visual Studio](https://visualstudio.microsoft.com/)**
2. **Install Dependencies**: If you haven't done so yet, make sure you have [.NET 6 SDK](https://dotnet.microsoft.com/download) installed.
Then, navigate to the project and restore the necessary packages by running:
   ```bash
   dotnet restore
   ```
3. **Run the project**: Build and run the project with Visual Studio debugger
