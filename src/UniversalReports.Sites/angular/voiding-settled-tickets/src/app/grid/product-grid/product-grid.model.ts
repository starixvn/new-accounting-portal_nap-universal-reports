export interface ProductItem {
    ProductGroupId: number;
    ProductGroup: string;
    HouseIncomeBeforeExtraPT: number;
    HouseIncomeAfterExtraPT: number;
}

export interface ProductData {
    Entities: ProductItem[];
    Total: ProductItem;
}
