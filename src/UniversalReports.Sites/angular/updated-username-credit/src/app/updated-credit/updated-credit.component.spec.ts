import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { UpdatedCreditComponent } from './updated-credit.component';

describe('UpdatedCreditComponent', () => {
  let component: UpdatedCreditComponent;
  let fixture: ComponentFixture<UpdatedCreditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdatedCreditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatedCreditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
