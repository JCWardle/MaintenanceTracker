exports.config = {
	seleniumAddress: 'http://localhost:4444/wd/hub',
	specs: ['login_spec.js'],
	multiCapabilities: [{
		browserName: 'firefox'
	}, {
		browserName: 'chrome'
	}]
}