use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;

fn main() {
    let input = read_input("./input");
    //println!("Input: {:?}", input);
    let score = roshambo(input);

    println!("Score: {}", score);
}

fn read_input(filename : &str) -> Vec<[char;2]> {
    let mut rounds : Vec<[char; 2]> = Vec::new();

    if let Ok(lines) = read_lines(filename) {
        for line in lines {
            if let Ok(play_str) = line {
                let plays : Vec<&str> = play_str.split(' ').collect();
                rounds.push([plays[0].chars().next().unwrap(), plays[1].chars().next().unwrap()]);
            }
        }
    }

    return rounds;
}

fn read_lines<P>(filename: P) -> io::Result<io::Lines<io::BufReader<File>>>
where P: AsRef<Path>, {
    let file = File::open(filename)?;
    Ok(io::BufReader::new(file).lines())
}

fn roshambo(input : Vec<[char; 2]>) -> u32 {
    let mut score: u32 = 0;

    for round in input {
        score += rsb_round(round);
    }

    return score;
}

fn rsb_round(input: [char;2]) -> u32 {
    let play_scores: [char; 3] = ['A', 'B', 'C'];
    let result_scores: [char; 3] = ['X', 'Y', 'Z'];

    let play_score: u32 = index_of(&play_scores, my_play(input)) + 1;
    let round_score: u32 = index_of(&result_scores, input[1]) * 3;

    //println!("In: {:?}\nPS: {}\nRS: {} = {}", input, play_score, round_score, play_score + round_score);

    return play_score + round_score;
}

fn index_of(arr: &[char], val: char) -> u32 {
    return u32::try_from(arr.iter().position(|&x| x == val).unwrap()).unwrap();
}

fn my_play(play: [char;2]) -> char {
    match play {
        ['A','X'] | ['B','Z'] => return 'C',
        ['B','X'] | ['C','Z'] => return 'A',
        ['C','X'] | ['A','Z'] => return 'B',
        _ => return play[0]
    }
}