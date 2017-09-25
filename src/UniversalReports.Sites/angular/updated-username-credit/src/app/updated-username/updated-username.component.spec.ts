import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { UpdatedUsernameComponent } from './updated-username.component';

describe('UpdatedUsernameComponent', () => {
  let component: UpdatedUsernameComponent;
  let fixture: ComponentFixture<UpdatedUsernameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdatedUsernameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatedUsernameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
