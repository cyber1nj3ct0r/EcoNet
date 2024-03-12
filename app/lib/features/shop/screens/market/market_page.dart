import 'package:app/common/custom_shape/widgets/cards/main_card/main_card.dart';
import 'package:app/common/custom_shape/widgets/slider/top_products_row/top_products_row.dart';
import 'package:app/common/custom_shape/widgets/slider/top_products_slider2.dart';
import 'package:app/features/shop/screens/farmers/top_farmers.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';
import '../../../../utils/constants/colors.dart';
import 'package:app/common/custom_shape/containers/search_container.dart';
import 'package:app/features/shop/screens/test.dart';
import 'package:app/utils/constants/image_strings.dart';

class MarketPage extends StatelessWidget {
  const MarketPage({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    final mediaqueryWidth = MediaQuery.of(context).size.width;
    final mediaqueryHeight = MediaQuery.of(context).size.height;
    return Scaffold(
      backgroundColor: const Color.fromARGB(255, 243, 240, 240),
      appBar: AppBar(
        backgroundColor: TColors.appPrimaryColor,
        title: PreferredSize(
          preferredSize: const Size.fromHeight(80),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              // welcome text
              Text('Welcome to ECO Net Market',
                  style: Theme.of(context)
                      .textTheme
                      .headlineSmall!
                      .apply(color: Colors.white)),
              // Welcome text subtitle
              Text('Lets buy some fresh and organic foods',
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
            // thia is green color container
            Container(
              width: double.infinity,
              height: MediaQuery.of(context).size.height * 0.4,
              color: TColors.appPrimaryColor,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  // This is search bar container
                  const Padding(
                    padding: EdgeInsets.all(15.0),
                    child: SearchBarContainer(
                      resultPage: Test(),
                      text: 'Search Products....',
                    ),
                  ),
                  SizedBox(height: mediaqueryHeight * 0.005),

                  //This is top Products
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        // top products title
                        Padding(
                          padding: const EdgeInsets.only(left: 10),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: [
                              const Text(
                                'Top Farmers',
                                style: TextStyle(
                                    fontSize: 20, color: Colors.white),
                              ),
                              InkWell(
                                  onTap: () {},
                                  child: const Text(
                                    'More Farmers',
                                    style: TextStyle(
                                        fontSize: 15, color: TColors.grey),
                                  )),
                            ],
                          ),
                        ),
                        const TopFarmers()
                      ],
                    ),
                  )
                ],
              ),
            ),

            // Main Category buttons
            Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: 20, vertical: 15),
                child: Column(
                  children: [
                    Text(
                      'Latest Products',
                      style: Theme.of(context).textTheme.bodyLarge,
                    ),
                    SizedBox(
                      height: mediaqueryHeight * .01,
                    ),
                    const TopProductsSlider()
                  ],
                )),
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
                          Text('All Products'),
                          Text('(130)'),
                        ],
                      ),
                      Row(
                        children: [
                          const Text('Filter Products'),
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
                              icon: Icon(Icons.filter_list),
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
                    height: mediaqueryHeight * 0.7, // Adjust the height
                    child: GridView.builder(
                      gridDelegate:
                          const SliverGridDelegateWithFixedCrossAxisCount(
                        crossAxisCount: 2,
                        crossAxisSpacing: 8.0,
                        mainAxisSpacing: 0,
                        mainAxisExtent: 300,
                      ),
                      itemCount: 30,
                      itemBuilder: (BuildContext context, int index) {
                        return Column(
                          children: [
                            Container(
                              decoration: BoxDecoration(
                                color: Colors.white,
                                border: Border.all(
                                    color:
                                        const Color.fromARGB(255, 86, 86, 86)),
                              ),
                              child: Center(
                                child: Column(
                                  children: [
                                    Padding(
                                      padding: const EdgeInsets.only(top: 5),
                                      child: Text(
                                        'Product $index',
                                        style: Theme.of(context)
                                            .textTheme
                                            .headlineSmall,
                                      ),
                                    ),
                                    const Image(
                                      image: AssetImage(TImages.p1),
                                      height: 100,
                                      fit: BoxFit.fill,
                                    ),
                                    Row(
                                      mainAxisAlignment:
                                          MainAxisAlignment.center,
                                      children: [
                                        Text(
                                          'Category:',
                                          style: Theme.of(context)
                                              .textTheme
                                              .bodySmall,
                                        ),
                                        Text(
                                          'Category1',
                                          style: Theme.of(context)
                                              .textTheme
                                              .bodyMedium,
                                        ),
                                      ],
                                    ),
                                    Row(
                                      mainAxisAlignment:
                                          MainAxisAlignment.center,
                                      children: [
                                        Text(
                                          '5',
                                          style: Theme.of(context)
                                              .textTheme
                                              .bodyLarge,
                                        ),
                                        const Icon(
                                          Icons.star_rate_outlined,
                                          color: Colors.amber,
                                        )
                                      ],
                                    ),
                                    Padding(
                                      padding: const EdgeInsets.symmetric(
                                          vertical: 10),
                                      child: Text(
                                        'RS 2400',
                                        style: Theme.of(context)
                                            .textTheme
                                            .headlineSmall,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                            ),
                            const SizedBox(
                              height: 5,
                            ),
                            SizedBox(
                              width: mediaqueryWidth * 0.5,
                              height: mediaqueryHeight * 0.07,
                              child: Container(
                                decoration: BoxDecoration(
                                  boxShadow: [
                                    BoxShadow(
                                      color: Colors.grey.withOpacity(0.5),
                                      spreadRadius: 2,
                                      blurRadius: 4,
                                      offset: const Offset(0, 2),
                                    ),
                                  ],
                                ),
                                child: ElevatedButton(
                                  onPressed: () {},
                                  child: const Text('Buy Now'),
                                ),
                              ),
                            ),
                          ],
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
