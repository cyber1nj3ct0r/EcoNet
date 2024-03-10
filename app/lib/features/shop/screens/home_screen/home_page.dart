import 'package:app/common/custom_shape/widgets/cards/main_card/service_card.dart';
import 'package:app/features/shop/screens/growing_crops/display_all_growing_crops.dart';
import 'package:app/features/shop/screens/market/market_page.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';
import '../../../../common/custom_shape/widgets/cards/main_card/rectangle_card_001.dart';
import '../../../../utils/constants/colors.dart';
import 'package:app/common/custom_shape/containers/search_container.dart';
import 'package:app/common/custom_shape/widgets/cards/main_card/main_card.dart';
import 'package:app/common/custom_shape/widgets/slider/top_products_row/top_products_row.dart';
import 'package:app/features/shop/screens/test.dart';
import 'package:app/utils/constants/image_strings.dart';

class HomePage extends StatelessWidget {
  const HomePage({
    Key? key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    // Get the screen height
    final mediaQuery = MediaQuery.of(context).size.height;

    return Scaffold(
      backgroundColor: const Color.fromARGB(255, 243, 240, 240),
      appBar: AppBar(
        backgroundColor: TColors.appPrimaryColor,
        title: PreferredSize(
          preferredSize: const Size.fromHeight(80),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              // Welcome text
              Text(
                'Welcome Kavindu',
                style: Theme.of(context)
                    .textTheme
                    .headlineSmall!
                    .apply(color: const Color.fromARGB(255, 248, 239, 239)),
              ),
              // Welcome text subtitle
              Text(
                'Let\'s build an agricultural country',
                style: Theme.of(context)
                    .textTheme
                    .bodySmall!
                    .apply(color: const Color.fromARGB(255, 218, 214, 214)),
              ),
            ],
          ),
        ),
        actions: [
          // Profile icon to navigate to the profile page
          InkWell(
            onTap: () {
              // Navigate to the profile page when the profile button is clicked
            },
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: InkWell(
                onTap: () {
                  Get.to(() => const Test());
                },
                child: const CircleAvatar(
                  radius: 16,
                  backgroundImage:
                      AssetImage(""), // Replace with your image asset
                ),
              ),
            ),
          ),
        ],
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            // Green color container
            Container(
              width: double.infinity,
              height: MediaQuery.of(context).size.height * 0.4,
              color: TColors.appPrimaryColor,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  // Search bar container
                  const Padding(
                    padding: EdgeInsets.all(15.0),
                    child: SearchBarContainer(
                      resultPage: Test(),
                      text: 'Search......',
                    ),
                  ),
                  SizedBox(height: mediaQuery * 0.005),

                  // Top Products
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        // Top products title
                        Padding(
                          padding: const EdgeInsets.only(left: 10),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: [
                              const Text(
                                'Top Products',
                                style: TextStyle(
                                  fontSize: 20,
                                  color: Colors.white,
                                ),
                              ),
                              InkWell(
                                onTap: () {},
                                child: const Text(
                                  'More Products',
                                  style: TextStyle(
                                    fontSize: 15,
                                    color: TColors.grey,
                                  ),
                                ),
                              ),
                            ],
                          ),
                        ),
                        const TopProducts(),
                      ],
                    ),
                  ),
                ],
              ),
            ),

            // Main Category buttons
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 25, vertical: 15),
              child: RectangleCard(
                x: 1,
                height: 100,
                title: 'Visit To Market Place',
                subtitle:
                    'You can buy Agriculture products \nusing our products market place',
                onTap: () {
                  Get.to(() => const MarketPage());
                },
                iconName: Icons.shop_two_outlined,
              ),
            ),
            // Add GridView here
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 5),
              child: ListView.builder(
                itemCount: 3,
                shrinkWrap: true,
                physics: const NeverScrollableScrollPhysics(),
                itemBuilder: (context, index) {
                  List<Map<String, String>> ServiceCards = [
                    {'title': 'Growing Crop 1', 'imageName': TImages.btnImg1},
                    {'title': 'Growing Crop 1', 'imageName': TImages.btnImg1},
                    {'title': 'Growing Crop 1', 'imageName': TImages.btnImg1},
                    {'title': 'Growing Crop 1', 'imageName': TImages.btnImg1},
                    {'title': 'Growing Crop 1', 'imageName': TImages.btnImg1},
                    {'title': 'Growing Crop 1', 'imageName': TImages.btnImg1},
                    {'title': 'Growing Crop 1', 'imageName': TImages.btnImg1},
                  ];
                  List<Widget> pageWidgets = [AllGrowingCrops()];

                  return Row(
                    mainAxisAlignment: MainAxisAlignment.spaceAround,
                    children: [
                      ServiceCard(
                        x: .4,
                        height: 120,
                        imageName: '${ServiceCards[index]['imageName']}',
                        title: '${ServiceCards[index]['title']}',
                        onTap: () {
                          Get.to(() => pageWidgets[index]);
                        },
                      ),
                      ServiceCard(
                        x: .4,
                        height: 120,
                        imageName: '${ServiceCards[index + 3]['imageName']}',
                        title: '${ServiceCards[index + 3]['title']}',
                        onTap: () {
                          Get.to(() => pageWidgets[index + 3]);
                        },
                      ),
                    ],
                  );
                },
              ),
            ),
          ],
        ),
      ),
    );
  }
}
