
context('Startup', () => {
  beforeEach(() => {
     
  });

    it('should fill login form', () => {
        Cypress.env('baseUrl');
        cy.visit(Cypress.env('baseUrl'));
      // cy.get('[data-cy="password"]').should('be.visible');btnSubmit
      // cy.get('[data-cy="password"]').should('be.visible');
      //cy.get('[data-cy="btnSubmit"]').should('be.visible');
      // Fill the username
      let username = Cypress.env('username');
        let password = Cypress.env('password');
        cy.get('input[name="Username"]')
            .type(username)
            .should('have.value', username);

      // Fill the password
        cy.get('input[name="Password"]').click()
            .type(password)

        cy.contains('button', 'Login').click();

        cy.contains('span', 'Home').should('be.visible');

  });

});