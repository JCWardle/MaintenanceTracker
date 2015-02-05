describe("Maintenance Tracker Register Page", function () {
    var username = element(by.id("Username"));
    var password = element(by.id("Password"));
    var confirmPassword = element(by.id("ConfirmPassword"));
    var email = element(by.id("Email"));
    var submit = element(by.css(".btn-success"));
    var errormessage = element(by.css("span.field-validation-error"));

    beforeEach(function () {
        browser.ignoreSynchronization = true;
        browser.get('http://mtracker/User/Register');
    });

    it("should have a title", function () {
        expect(browser.getTitle()).toEqual("Register - Maintenance Tracker");
    });

    it("registers a new user", function() {
        username.sendKeys("user1");
        password.sendKeys("password");
        confirmPassword.sendKeys("password");
        email.sendKeys("test@test.com");

        submit.click();

        expect(browser.getCurrentUrl()).toEqual("http://mtracker");
    });

    it("requires a username", function() {
        submit.click();
        
        username.getAttribute("class").then(function (attr) {
            expect(attr).toContain("input-validation-error");
        });
    });

    it("requires a password", function () {
        submit.click();
        
        password.getAttribute("class").then(function (attr) {
            expect(attr).toContain("input-validation-error");
        });
    });

    it("requires a confirmation password", function () {
        submit.click();
        
        confirmPassword.getAttribute("class").then(function (attr) {
            expect(attr).toContain("input-validation-error");
        });
    });

    it("requires the same password and confirmation password", function() {
        username.sendKeys("abcdef");
        password.sendKeys("def");
        confirmPassword.sendKeys("abc");
        submit.click();
        
        expect(errormessage.getText()).toBe("Your passwords must match");
    });

    it("doesn't allow the same username to register twice", function() {
        username.sendKeys("user1");
        password.sendKeys("password");
        confirmPassword.sendKeys("password");
        email.sendKeys("test@test.com");
        
        submit.click();

        expect(errormessage.getText()).toBe("")
    });
});