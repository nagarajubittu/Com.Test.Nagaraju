Feature: OrderTShirtAndVerify
	As a user
	I want to buy a T-shirt and verify order history

Scenario: Order T-Shirt and Verify order details
Given i navigate to home page
And i click on Tshirts
When i select one of the T-shirts and i add to cart
And i click on checkout
And i click on proceed to checkout at order summary step
And click to proceed at address step
And i agree for T&C at shipping step and click to proceed
And i click on pay by check
And i navigate to confirm order
And my order should be completed successfully
And i click on back to orders
Then i navigate to order history page
And verify order details



