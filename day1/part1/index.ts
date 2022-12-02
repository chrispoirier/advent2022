import * as fs from 'fs/promises';

try {
  const filePath = new URL('./input.txt', import.meta.url);
  const contents = await fs.readFile(filePath, { encoding: 'utf8' });

  let linesIn = contents.split('\r\n\r\n');
  let lines : string[][] = [];
  linesIn.forEach(line => {
    lines.push(line.split('\r\n'));
  });
  //console.log(lines);

  let max = 0;
  lines.forEach(line => {
    let sum = 0;
    line.forEach(element => {
      sum += parseInt(element);
    });
    if (sum > max) {
      max = sum;
    }
  });

  console.log("Most calories: " + max)
} catch (err) {
  console.error((err as Error).message);
}