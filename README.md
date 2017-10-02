# Android News app x3

This is the same functionality is implemented twice in these two technologies:

- Xamarin
- React Native

I wanted to test the hypothesis that there are so many good native cross-platform technologies now that there is no excuse to write apps for Android only. What better way to test for an Android developer than to dive into two unknown technologies: Xamarin and React Native, and see what the experience is. The "third app" is the common article presentation layer I've worked with for the [VG](https://play.google.com/store/apps/details?id=com.agens.android.vgsnarvei)* and [Aftonbladet](https://play.google.com/store/apps/details?id=se.aftonbladet.start) apps for Schibsted.

_\*) Native functionality not yet released to the Play Store as of Oct 2nd 2017_

## Running

**The Xamarin project**:

Simply install VS2015 (recommended) or VS2017 preview ad open the project. It's compatible with both. Do remember to install the Xamarin modules when installing the IDE.

**The React Native project**

Make sure you have

 - Installed Node.js v6 or higher (tested with v6)
 - Installed Python2 
 - Installed Java7 or newer, preferrably 64 bit version
 - Configured your `ANDROID_HOME` and `JAVA_HOME` environment variabless
 
Run the app for the first time with:

 - `npm install -g react-native-cli`
 - `npm install`
 - `react-native run-android`
 
## Platform tutorials and documentation

- [React Native](https://facebook.github.io/react-native/docs/getting-started.html)
- [Xamarin.Android](https://developer.xamarin.com/guides/android/)

Frode Nilsen.

Twitter: [@nilzor](https://twitter.com/Nilzor)
Mail: frode.nilsen@schibsted.com
