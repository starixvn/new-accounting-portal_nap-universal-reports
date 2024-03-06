export interface ResultAnalysisSummaryModel {
    TotalLeague: number;
    TotalMatch: number;
    FavHdpResult: number;
    UnderdogHdpResult: number;
    DrawHdpResult: number;
    OverOuResult: number;
    UnderOuResult: number;
    DrawOuResult: number;
    Fav1x2Result: number;
    Underdog1x2Result: number;
    Draw1x2Result: number;
    TgResult01: number;
    TgResult23: number;
    TgResult46: number;
    TgResult7: number;
}

export interface DetailedResultAnalysisModel {
    Date: string;
    League: string;
    Match: string;
    HDP: number;
    OU: number;
    Fav: string;
    HtScoreHome: number;
    HtScoreAway: number;
    FtScoreHome: number;
    FtScoreAway: number;
    ResultHDP: string;
    ResultOU: string;
    Result1x2: string;
    ResultTG: number;
}

export interface ResultAnalysisModel {
    Items: DetailedResultAnalysisModel[];
    Summary: ResultAnalysisSummaryModel;
}
