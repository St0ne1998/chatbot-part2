CybersecurityBot (WEchat) - Project Documentation & Portfolio Report (Part 1 & Part 2)
Author: Amusement Lubisi

Student Number: st10500573

Institution: Rosebank College

Module: PROG6221 POE

1. Project Overview & Evolution
CybersecurityBot (affectionately known as WEchat) is an interactive educational software application designed to empower users with essential cybersecurity awareness, threat mitigation strategies, and best practices.

Part 1: Established the foundational core in C# as a structured console application featuring modular architecture, ASCII banner presentation, top-level exception handling, and .wav audio greeting integration.

Part 2: Evolves the software into a professional Windows Forms Graphical User Interface (GUI) application. It incorporates multi-step state-driven user profiling (capturing name and age), dynamic randomized responses using generic collections (Dictionary, List), sentiment detection for empathetic bot adaptation, conversation follow-up flow, and robust session memory recall.

2. Technical Architecture & Component Breakdown
The application follows a clean Object-Oriented Programming (OOP) design pattern, separating concerns across distinct classes:

Program.cs: Serves as the application entry point, enabling visual styles and initializing the main Windows Forms session inside a protected try-catch block.

MainForm.cs: Manages the graphical interface layout, featuring a dark-themed ASCII art header ("WE CHAT BOT"), a responsive chat history display (RichTextBox), and event-driven message input handling.

ChatBotEngine.cs: Houses the core dialogue manager, keyword matching dictionary, randomized response selection algorithm, and the multi-step startup state machine (gathering name and age sequentially).

MemoryManager.cs: Captures and stores user profile attributes (name, age) and records topic interests dynamically during the conversation session for later recall.

SentimentAnalyzer.cs: Inspects user input strings for keywords indicating emotional tone (such as worry, curiosity, or frustration) and injects empathetic guidance into the bot's response prefix.

AudioPlayer.cs: Handles programmatic audio playback using System.Media.SoundPlayer to execute the greeting.wav welcome clip upon startup.

2. References & Academic Documentation
Microsoft Corporation. (2026). C# Guide and Console/Windows Forms Applications. Retrieved from https://learn.microsoft.com/en-us/dotnet/csharp/

Microsoft Corporation. (2026). SoundPlayer Class (System.Media). Retrieved from https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer

The Independent Institute of Education (IIE). (2026). PROG6221 Module Guide and POE Specifications (Part 1 & Part 2). Rosebank College.