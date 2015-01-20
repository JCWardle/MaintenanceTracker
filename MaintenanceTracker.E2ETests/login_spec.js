describe("Maintenance Tracker Login Page", function()
{
    var username = element(by.id("Username"));
    var password = element(by.id("Password"));
    var login = element(by.css(".btn-success"));
    var errormessage = element(by.css("span.field-validation-error"));

	beforeEach(function() {
	    browser.ignoreSynchronization = true;
        browser.get('http://mtracker');
	});

	it("should have a title", function(){
		expect(browser.getTitle()).toEqual("Login - Maintenance Tracker");
    });

    it("should require a username", function() {
        login.click();

        username.getAttribute("class").then(function (attr) {
            expect(attr).toContain("input-validation-error");
        });
    });

    it("should require a password", function () {
        login.click();
        
        password.getAttribute("class").then(function (attr) {
            expect(attr).toContain("input-validation-error");
        });
    });

    it("should require a password with a username", function() {
        username.sendKeys("ABC");
        login.click();

        password.getAttribute("class").then(function (attr) {
            expect(attr).toContain("input-validation-error");
        });
    });

    it("should require a username with a password", function() {
        password.sendKeys("abc");
        login.click();

        username.getAttribute("class").then(function (attr) {
            expect(attr).toContain("input-validation-error");
        });
    });

    it("should display a error message when given invalid credentials", function() {
        username.sendKeys("abc");
        password.sendKeys("abc");
        login.click();

        expect(errormessage.getText()).toBe("Invalid Username and Password");
    });
});