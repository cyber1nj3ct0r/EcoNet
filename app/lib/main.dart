import 'package:app/features/shop/screens/home_screen/home_page.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

import 'navigation_menu.dart';
import 'utils/theme/theme.dart';

void main() {
  runApp(const App());
}

class App extends StatelessWidget {
  const App({super.key});

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: GetMaterialApp(
        debugShowCheckedModeBanner: false,
        themeMode: ThemeMode.system,
        theme: TAppTheme.lightTheme,
        darkTheme: TAppTheme.darkTheme,
        home: NavigationMenu(),
      ),
    );
  }
}
