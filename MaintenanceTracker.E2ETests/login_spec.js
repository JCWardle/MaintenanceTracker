describe('Maintenance Tracker Login Page', function()
{
	beforeEach(function() {
	    browser.ignoreSynchronization = true;
        browser.get('http://mtracker');
	});

	it('should have a title', function(){
		expect(browser.getTitle()).toEqual('Login - Maintenance Tracker');
	});
});