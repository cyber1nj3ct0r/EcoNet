import 'package:app/common/custom_shape/widgets/cards/main_card/service_card.dart';
import 'package:app/features/shop/screens/coomunity/common_post/common_post.dart';
import 'package:app/features/shop/screens/growing_crops/display_all_growing_crops.dart';
import 'package:app/features/shop/screens/market/market_page.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';
import '../../../../common/custom_shape/widgets/cards/main_card/rectangle_card_001.dart';
import '../../../../utils/constants/colors.dart';
import 'package:app/common/custom_shape/containers/search_container.dart';
import 'package:app/common/custom_shape/widgets/slider/top_products_row/top_products_row.dart';
import 'package:app/features/shop/screens/test.dart';
import 'package:app/utils/constants/image_strings.dart';

class CommunityPage extends StatelessWidget {
  const CommunityPage({
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
                'Welcome to ECO Net Community',
                style: Theme.of(context)
                    .textTheme
                    .headlineSmall!
                    .apply(color: const Color.fromARGB(255, 248, 239, 239)),
              ),
              // Welcome text subtitle
              Text(
                'Ask Quectioons and find solutions',
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
              height: MediaQuery.of(context).size.height * 0.2,
              color: TColors.appPrimaryColor,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  // Search bar container
                  const Padding(
                    padding: EdgeInsets.all(15.0),
                    child: SearchBarContainer(
                      resultPage: Test(),
                      text: 'Type Keyword...',
                    ),
                  ),
                  SizedBox(height: mediaQuery * 0.005),
                ],
              ),
            ),

            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  TextButton(
                      onPressed: () {},
                      child: Text(
                        'Click to make Quection',
                        style: Theme.of(context).textTheme.headlineSmall,
                      )),
                  const CommonPost(),
                  const CommonPost(),
                  const CommonPost(),
                  const CommonPost(),
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}
