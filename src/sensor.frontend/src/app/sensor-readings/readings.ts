export interface Readings {
  values: number[];
  timestamps: Date[];
  maxValue: number;
  minValue: number;
  type: string;
  sensorId: number;
}
