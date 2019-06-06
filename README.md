# 2019_NOKIAspectrum
## Overview
Desktop app do Fast Fourier Transform, then use USB to communicate with microcontroller. STM interprets data and display them in real-time at HD44780 display as Audio Spectrum.
## Hardware & software
- Visual Studio 2017 15.9
- GIMP 2.10.8
- Unity 2019.1.1f1
- STM32407FG Discovery
- CubeMX
- Eclipse
- LCD 2x16 HD44780 
- UART
## Technology
- C# & WPF - MusicPlayer
- C# Unity - FFT
- C - STM32F4
## How to run
- You can run MusicPlayer without performing FFT (music spectrum) just by drag & drop music file on program window. The music will automatically run after drop. You can use any music extension.
- To run MusicPlayer with spectrum (FFT) you have to launch player, then press <img src="https://github.com/PUT-PTM/2019_NOKIAspectrum/blob/master/MusicPlayer/Assets/spectrumButton2.png" width="16px" height="16px"> button. After that you have to launch Unity project.
- If you done previous steps you can plug in UART connected to STM32 with STM32F4 project.
## How to compile
- MusicPlayer - set in USB class comPort.PortName. By default it is COM8.
- Unity - build is fragile (for your safety don't compile).
- STM32F4 project - you have to generate project with CubeMX (you should use .ioc file), next connect display and UART with microcontroller

## Pin connect pattern
- V0 - GND
- RW - GND
- VSS - GND
- VDD - 5V
- A - 3.3V
- K - GND
- E - PE1
- Rs - Rs
- TxD - PC11
- RxD - PC10
- GND - GND

## Future improvements
- Playlist display
- Change volume with click on ProgressBar
- Drop multiple files
- After start check standard input
- FFT in MusicPlayer
## License
- MIT

## Credits 
Michał Rychlik, Kornel Kaczmarek
<hr>
The project was conducted during the Microprocessor Lab course held by the Institute of Control and Information Engineering, Poznan University of Technology. Supervisor: Tomasz Mańkowski
