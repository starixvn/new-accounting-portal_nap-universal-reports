import { Component } from '@angular/core';
import * as _ from 'lodash';
import { PaginationInstance, PaginatePipe, PaginationService as NgxPaginationService } from 'ngx-pagination';
import { PaginationService } from 'nap-components/pagination';
import { Grid, MemberModel } from './../common/model';
import { MemberGridService } from './member-grid.service';

@Component({
  selector: 'app-member-grid',
  templateUrl: './member-grid.component.html',
  styleUrls: ['./member-grid.component.scss'],
  providers: [
    MemberGridService
  ]
})
export class MemberGridComponent implements Grid {
  breadcrumbItems: string[];
  memberData: MemberModel[] = [];
  displayMember: MemberModel[];
  paginationInstance: PaginationInstance;
  private paginatePipe: PaginatePipe;

  constructor(
    private readonly memberGridService: MemberGridService,
    private paginationService: PaginationService,
    private ngxPaginationService: NgxPaginationService) {
    this.paginatePipe = new PaginatePipe(this.ngxPaginationService);
  }

  query() {
    this.memberGridService.query().subscribe(data => {
      const breadcrumb = this.memberGridService.title;
      this.breadcrumbItems = [breadcrumb];
      this.memberData = data;
      this.paginationInstance = this.paginationService.createPaginationInstance(this.memberData.length);
      this.onPageChange();
    });
  }

  exportExcel() {
    this.memberGridService.exportExcel();
  }

  get hasExcel(): boolean {
    return this.hasData;
  }

  get hasData(): boolean {
    return !_.isNil(this.memberData) && this.memberData.length > 0;
  }

  get title(): string {
    return 'Member';
  }

  onPageChange() {
    this.createExchangePaging();
  }

  private createExchangePaging() {
    const paginateMember = this.paginatePipe.transform(this.memberData, this.paginationInstance);
    this.displayMember = _.cloneDeep(paginateMember);
  }
}
