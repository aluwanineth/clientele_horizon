const { defineConfig } = require("cypress");

module.exports = defineConfig({
    env: {
        baseUrl: "https://localhost:7137/",
        login_url: '/login',
        products_url: '/products',
        username: 'svc_Horizon_D_Intrnl@clientele.co.za',
        password: '$c$N7T85&CEq'
    },
    e2e: {
        baseUrl: "https://localhost:7137/",
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
  },
});
