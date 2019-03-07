# Kata_GrocerPOS

To test:

Running this program in visual studio should work out of box. It requires no special NuGet packages or otherwise. 

I was able to clone and run the tests on a clean visual studio install. Please let me know if you have any issues running the process and I'll get them fixed ASAP.

Here are the steps I took (after installing a fresh copy of VS on my laptop)
1. Cloned the repository
2. Navigated to the git repo via File Explorer
3. Opened "Grocer.sln"
4. Opened up a UnitTest file (in my case I clicked "CartTests.cs")
5. Right clicked over a test to open up the menu dialog
6. Clicked "Run Tests"


A few notes:

There are quite a few changes I would make to the project, looking back. Here's a short list

1. Give deals their own data dictionary, similar to how I handled Inventory. 
2. I started unit testing at work and have found some handy ways to think about writing tests. At the beginning I think I was unit testing poorly, or maybe not thinking about what I needed to be testing thoroughly enough.
3. I was given the advice to trim my commits, which is totally fine, but about a year ago when I did the Kata the first time, I was told they wanted to see me write a test (red) and then write the code to turn that test green.
	However, looking back, I wrote batches of tests on that one. So maybe that's what my reviewer was getting at. I'd say it's pretty likely, and I ended up going over the top this time.
4. If you look in InventoryItem you'll see I override GetHashCode(), there are probably a dozen and a half better ways to go about overriding this method, but I ultimately decided it wasn't an issue worth worrying over for the KATA,
	But it could prove problematic in a larger scope.

	
I'm really looking for feedback based on how I approached testing. While I have improved via performing TDD at work, I would love to hear some more about potential better approaches I could be taking.

	
Overall I am much happier with this Kata than my last (https://github.com/HunterSLind/VendingKata_Retry) No matter how this ends up, I'm really happy that I can walk away from this saying I've tangibly improved. 


Thank you for your time.

Hunter Lind