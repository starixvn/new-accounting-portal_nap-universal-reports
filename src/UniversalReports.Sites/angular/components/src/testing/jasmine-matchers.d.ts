declare namespace jasmine {
  interface Matchers<T> {
    toHaveCssClass(expected: string, expectationFailOutput?: any): boolean;
    toHaveCssStyle(expected: object, expectationFailOutput?: any): boolean;
    toHaveText(expected: string, expectationFailOutput?: any): boolean;
  }
}
