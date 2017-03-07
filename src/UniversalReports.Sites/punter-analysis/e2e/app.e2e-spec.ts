import { PunterAnalysisPage } from './app.po';

describe('punter-analysis App', () => {
  let page: PunterAnalysisPage;

  beforeEach(() => {
    page = new PunterAnalysisPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
