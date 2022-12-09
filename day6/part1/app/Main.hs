module Main where

import Control.Exception
import Paths_part1

main :: IO ()
main = 
    do  inputContents <- readInputFile("input")
        --putStrLn inputContents
        putStrLn (show (findSOP inputContents))    

readInputFile :: String -> IO String
readInputFile name =
    handle(\(SomeException e) -> error("Error reading file:"++ name ++"\n"++ displayException e)) 
        (do filePath <- getDataFileName name
            readFile filePath
        )

findSOP :: String -> Int
findSOP contents = (findSOPRec contents 0) + 4

findSOPRec :: String -> Int -> Int
findSOPRec contents acc =
    case take 4 contents of {
        [] -> error "No SOP found!";
        xs -> 
            if hasDups xs
                then findSOPRec (tail contents) acc+1
                else acc
    }

hasDups :: String -> Bool
hasDups check = 
    case check of {
        "" -> False;
        (x:xs) -> 
            if x `elem` xs
                then True
                else hasDups xs
    }
