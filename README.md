# builderpattern

Key implementation in this POC:

1. Builder pattern - I am using this pattern to build the response in a readable way.
2. Cognitive search - Integration with Cognitive Search API.
3. TPL - Performing two different actions at the same time using Task Parallel Library.
4. Exception handler - Using a global exception handler to log and return proper response from API.

PLEASE READ:

I did NOT use some best practices like SOLID principles. All models, services and providers and in the same project just for this POC purposes. Please ignore the architecture of this project.

Also, the key and secret from cognitive search service are empty for security reasons, however, I am attaching the following screenshot to show you that this works as expected:

![image](https://user-images.githubusercontent.com/60451076/228695423-ae50c2c7-bc63-4fe4-af57-16e06d345c73.png)
