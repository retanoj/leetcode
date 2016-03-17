using System;

namespace leetcode
{
	public class IsValidSudokuCls
	{
		public bool IsValidSudoku(char[,] board) {
			//check row
			for(int i=0; i<9; i++){
				int row = 0;
				for(int j=0; j<9; j++){
					if(board[i,j] == '.'){
						continue;
					}else{
						int tmp = board[i,j] - '0';
						if( ( (row & (1 << tmp) ) >> tmp ) == 1){
							return false;
						}
						row |= (1 << tmp);
					}
				}
			}

			//check col
			for(int j=0; j<9; j++){
				int col = 0;
				for(int i=0; i<9; i++){
					if(board[i,j] == '.'){
						continue;
					}else{
						int tmp = board[i,j] - '0';
						if( ( (col & (1 << tmp) ) >> tmp ) == 1){
							return false;
						}
						col |= (1 << tmp);
					}
				}
			}

			//check block
			for(int i=0; i<9; i+=3){
				for(int j=0; j<9; j+=3){
					int block = 0;
					for(int ii=0; ii<3; ii++){
						for(int jj=0; jj<3; jj++){
							if(board[i+ii, j+jj] == '.'){
								continue;
							}else{
								int tmp = board[i+ii, j+jj] - '0';
								if( ( (block & (1 << tmp) ) >> tmp ) == 1){
									return false;
								}
								block |= (1 << tmp);
							}
						}
					}
				}
			}
			return true;
	
		}
	}
}

