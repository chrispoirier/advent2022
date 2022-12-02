import * as fs from 'fs/promises';
try {
    const filePath = new URL('./input.txt', import.meta.url);
    const contents = await fs.readFile(filePath, { encoding: 'utf8' });
    let linesIn = contents.split('\r\n\r\n');
    let lines = [];
    linesIn.forEach(line => {
        lines.push(line.split('\r\n'));
    });
    let maxes = [0, 0, 0];
    lines.forEach(line => {
        let sum = 0;
        line.forEach(element => {
            sum += parseInt(element);
        });
        if (sum > maxes[0]) {
            maxes[2] = maxes[1];
            maxes[1] = maxes[0];
            maxes[0] = sum;
        }
        else if (sum > maxes[1]) {
            maxes[2] = maxes[1];
            maxes[1] = sum;
        }
        else if (sum > maxes[2]) {
            maxes[2] = sum;
        }
    });
    console.log(maxes);
    console.log("Most calories: " + (maxes[0] + maxes[1] + maxes[2]));
}
catch (err) {
    console.error(err.message);
}
