import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TraingleComponent } from './triangle.component';

describe('TraingleComponent', () => {
  let component: TraingleComponent;
  let fixture: ComponentFixture<TraingleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TraingleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TraingleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

});
