import { BuildingTutsTemplatePage } from './app.po';

describe('BuildingTuts App', function() {
  let page: BuildingTutsTemplatePage;

  beforeEach(() => {
    page = new BuildingTutsTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
