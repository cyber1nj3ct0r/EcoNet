import 'package:app/common/custom_shape/widgets/cards/groving_crops/groving_crops_display_card.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';
import '../../../../utils/constants/colors.dart';
import 'package:app/common/custom_shape/containers/search_container.dart';
import 'package:app/features/shop/screens/test.dart';
import 'package:app/utils/constants/image_strings.dart';

import 'growing_crop_details.dart';

class AllGrowingCrops extends StatelessWidget {
  AllGrowingCrops({
    super.key,
  });
  List<Map<String, String>> GrowingCrops = [
    {'title': 'Growing Crop 1', 'imageName': TImages.p1},
    {'title': 'Growing Crop 2', 'imageName': TImages.p2},
    {'title': 'Growing Crop 3', 'imageName': TImages.p3},
    {'title': 'Growing Crop 4', 'imageName': TImages.p1},
    {'title': 'Growing Crop 5', 'imageName': TImages.p1},
    {'title': 'Growing Crop 6', 'imageName': TImages.p1},
    {'title': 'Growing Crop 7', 'imageName': TImages.p2},
    {'title': 'Growing Crop 7', 'imageName': TImages.p2},
  ];
  @override
  Widget build(BuildContext context) {
    final mediaqueryWidth = MediaQuery.of(context).size.width;
    final mediaqueryHeight = MediaQuery.of(context).size.height;
    return Scaffold(
      backgroundColor: const Color.fromARGB(255, 243, 240, 240),
      appBar: AppBar(
        toolbarHeight: 80,
        backgroundColor: TColors.appPrimaryColor,
        title: PreferredSize(
          preferredSize: const Size.fromHeight(80),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(
                height: 10,
              ),
              Text('Growing Crops in Sri Lanka',
                  style: Theme.of(context)
                      .textTheme
                      .headlineSmall!
                      .apply(color: Colors.white)),
              // Welcome text subtitle
              Text('Here main growing crops metheds\nin sri lanka',
                  style: Theme.of(context)
                      .textTheme
                      .bodySmall!
                      .apply(color: const Color.fromARGB(255, 218, 214, 214))),
            ],
          ),
        ),
        actions: [
          // this is profile icon.navigate to profile page
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
                  radius: 16, // Adjust the size as needed
                  backgroundImage: AssetImage(
                      TImages.farmer1), // Replace with your image asset
                ),
              ),
            ),
          ),
        ],
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            // thia is green color container
            Container(
              width: double.infinity,
              height: MediaQuery.of(context).size.height * 0.15,
              color: TColors.appPrimaryColor,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  // This is search bar container
                  const Padding(
                    padding: EdgeInsets.all(15.0),
                    child: SearchBarContainer(
                      resultPage: Test(),
                      text: 'Search Growing Crops....',
                    ),
                  ),
                  SizedBox(height: mediaqueryHeight * 0.005),

                  //This is top Products
                ],
              ),
            ),
            SizedBox(
              height: mediaqueryHeight * .01,
            ),
            // Add GridView here
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 10),
              child: Column(
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      const Row(
                        children: [
                          Text('All Growing Crops'),
                          Text('(10)'),
                        ],
                      ),
                      Row(
                        children: [
                          const Text('Filter Growing Crops'),
                          SizedBox(
                            width: mediaqueryWidth * .01,
                          ),
                          Container(
                            height: 40,
                            width: 40,
                            decoration: BoxDecoration(
                                color: Colors.black,
                                borderRadius: BorderRadius.circular(5)),
                            child: IconButton(
                              onPressed: () {},
                              icon: const Icon(Icons.filter_list),
                              color: Colors.white,
                            ),
                          )
                        ],
                      )
                    ],
                  ),
                  SizedBox(
                    height: mediaqueryHeight * 0.02,
                  ),
                  SizedBox(
                    width: mediaqueryWidth,
                    height: mediaqueryHeight * 0.6, // Adjust the height
                    child: GridView.builder(
                      gridDelegate:
                          const SliverGridDelegateWithFixedCrossAxisCount(
                        crossAxisCount: 2,
                        crossAxisSpacing: 8.0,
                        mainAxisSpacing: 0,
                        mainAxisExtent: 190,
                      ),
                      itemCount: 8,
                      itemBuilder: (BuildContext context, int index) {
                        return GrovingCropsDisplayCard(
                          title: '${GrowingCrops[index]['title']}',
                          image: '${GrowingCrops[index]['imageName']}',
                          onTap: () {
                            Get.to(() => GrowingCropDetailPage(
                                  index: index,
                                ));
                          },
                        );
                      },
                    ),
                  ),
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}
