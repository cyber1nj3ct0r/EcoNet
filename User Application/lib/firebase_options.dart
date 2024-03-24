// File generated by FlutterFire CLI.
// ignore_for_file: lines_longer_than_80_chars, avoid_classes_with_only_static_members
import 'package:firebase_core/firebase_core.dart' show FirebaseOptions;
import 'package:flutter/foundation.dart'
    show defaultTargetPlatform, kIsWeb, TargetPlatform;

/// Default [FirebaseOptions] for use with your Firebase apps.
///
/// Example:
/// ```dart
/// import 'firebase_options.dart';
/// // ...
/// await Firebase.initializeApp(
///   options: DefaultFirebaseOptions.currentPlatform,
/// );
/// ```
class DefaultFirebaseOptions {
  static FirebaseOptions get currentPlatform {
    if (kIsWeb) {
      return web;
    }
    switch (defaultTargetPlatform) {
      case TargetPlatform.android:
        return android;
      case TargetPlatform.iOS:
        return ios;
      case TargetPlatform.macOS:
        return macos;
      case TargetPlatform.windows:
        throw UnsupportedError(
          'DefaultFirebaseOptions have not been configured for windows - '
          'you can reconfigure this by running the FlutterFire CLI again.',
        );
      case TargetPlatform.linux:
        throw UnsupportedError(
          'DefaultFirebaseOptions have not been configured for linux - '
          'you can reconfigure this by running the FlutterFire CLI again.',
        );
      default:
        throw UnsupportedError(
          'DefaultFirebaseOptions are not supported for this platform.',
        );
    }
  }

  static const FirebaseOptions web = FirebaseOptions(
    apiKey: 'AIzaSyAzgNDZw2BM6zDWFXgQheKAXYbyIWGE2C8',
    appId: '1:153692598076:web:40d0af6482a5d91b2ab839',
    messagingSenderId: '153692598076',
    projectId: 'econet-store',
    authDomain: 'econet-store.firebaseapp.com',
    storageBucket: 'econet-store.appspot.com',
    measurementId: 'G-SLWPB4RCP4',
  );

  static const FirebaseOptions android = FirebaseOptions(
    apiKey: 'AIzaSyBESlnUgKnMBshdYjh-e1R_5kQubzgYUTc',
    appId: '1:153692598076:android:26da01b0385e55102ab839',
    messagingSenderId: '153692598076',
    projectId: 'econet-store',
    storageBucket: 'econet-store.appspot.com',
  );

  static const FirebaseOptions ios = FirebaseOptions(
    apiKey: 'AIzaSyBzCgXg06Fr4R4DitkBWIEVh_MH4LkQZXM',
    appId: '1:153692598076:ios:de5446fe29fb3bf12ab839',
    messagingSenderId: '153692598076',
    projectId: 'econet-store',
    storageBucket: 'econet-store.appspot.com',
    iosBundleId: 'com.example.app',
  );

  static const FirebaseOptions macos = FirebaseOptions(
    apiKey: 'AIzaSyBzCgXg06Fr4R4DitkBWIEVh_MH4LkQZXM',
    appId: '1:153692598076:ios:6d2cc401e44ff7ab2ab839',
    messagingSenderId: '153692598076',
    projectId: 'econet-store',
    storageBucket: 'econet-store.appspot.com',
    iosBundleId: 'com.example.app.RunnerTests',
  );
}
