import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SensorReadingsComponent } from './sensor-readings.component';

describe('SensorReadingsComponent', () => {
  let component: SensorReadingsComponent;
  let fixture: ComponentFixture<SensorReadingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SensorReadingsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SensorReadingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
