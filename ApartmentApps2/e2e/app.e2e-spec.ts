import { SingPage } from './app.po';

describe('sing App', function() {
  let page: SingPage;

  beforeEach(() => {
    page = new SingPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
