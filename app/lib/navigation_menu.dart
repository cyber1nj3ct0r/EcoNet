import 'package:app/features/shop/screens/coomunity/community_page.dart';
import 'package:app/features/shop/screens/home_screen/home_page.dart';
import 'package:app/features/shop/screens/market/market_page.dart';
import 'package:app/utils/constants/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';
import 'package:iconsax/iconsax.dart';

class NavigationMenu extends StatelessWidget {
  const NavigationMenu({super.key});

  @override
  Widget build(BuildContext context) {
    final controller = Get.put(NavigationController());

    return Scaffold(
      bottomNavigationBar: Obx(
        () => NavigationBar(
          indicatorColor: TColors.appPrimaryColor,
          height: 80,
          elevation: 0,
          selectedIndex: controller.selectedIndex.value,
          onDestinationSelected: (index) =>
              controller.selectedIndex.value = index,
          destinations: const [
            NavigationDestination(icon: Icon(Iconsax.home), label: 'Home'),
            NavigationDestination(icon: Icon(Iconsax.shop), label: 'Market'),
            NavigationDestination(
                icon: Icon(Icons.group_add_outlined), label: 'Community'),
            NavigationDestination(
                icon: Icon(Iconsax.notification), label: 'Notification'),
          ],
        ),
      ),
      body: Obx(() => controller.screens[controller.selectedIndex.value]),
    );
  }
}

class NavigationController extends GetxController {
  final Rx<int> selectedIndex = 0.obs;

  final screens = [
    const HomePage(),
    const MarketPage(),
    const CommunityPage(),
    Container(color: Colors.blue)
  ];
}
