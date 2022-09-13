using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.Analysis;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace BadmintonApp
{
    public partial class Form2 : Form
    {
        Form1 frm1;
        List<List<Object>> rallies;

        bool situationSelected = false;
        Button situationButtonSelected = null;

        private System.Windows.Forms.DataVisualization.Charting.Chart chart { get; set; }

        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form callingForm)
        {
            frm1 = callingForm as Form1;
            InitializeComponent();
        }

        private Tuple<int, int> GetScore(List<List<Object>> list, int amount)
        {
            int playerScore = 0;
            int opponentScore = 0;
            int i = 0;
            foreach (List<Object> rally in list)
            {
                if (i >= amount)
                {
                    break;
                }

                if (rally[^1].ToString() == "Player")
                {
                    playerScore++;
                }
                else if (rally[^1].ToString() == "Opponent")
                {
                    opponentScore++;
                }

                i++;
            }

            return Tuple.Create<int, int>(playerScore, opponentScore);
        }

        public Point GetPointFromObject(Object obj)
        {
            int X = int.Parse(Regex.Match(obj.ToString(), "(?<=X=)(.*)(?=,)").Groups[0].Value);
            int Y = int.Parse(Regex.Match(obj.ToString(), "(?<=Y=)(.*)(?=})").Groups[0].Value);
            return new Point(X, Y);
        }

        private Tuple<Point, Point> GetShotLocation(int rally, int shot)
        {
            DataFrame df = new DataFrame();
            foreach(List<Object> list in rallies)
            {
                if (list == rallies[rally - 1])
                {
                    df = list[0] as DataFrame;

                    Debug.WriteLine(GetPointFromObject(df.Rows[shot - 1][2]));
                    Debug.WriteLine(GetPointFromObject(df.Rows[shot - 1][3]));
                }
            }

            return Tuple.Create(GetPointFromObject(df.Rows[shot - 1][2]), GetPointFromObject(df.Rows[shot - 1][3]));
        }

        private DataFrameRow GetShot(int rally, int shot)
        {
            DataFrame df = new DataFrame();
            foreach (List<Object> list in rallies)
            {
                if (list == rallies[rally - 1])
                {
                    df = list[0] as DataFrame;

                    Debug.WriteLine(GetPointFromObject(df.Rows[shot - 1][2]));
                    Debug.WriteLine(GetPointFromObject(df.Rows[shot - 1][3]));
                }
            }

            return df.Rows[shot - 1];
        }

        private string GetShotType(int rally, int shot)
        {
            return GetShot(rally, shot)[4].ToString();
        }

        private void SetStatistics(Panel tempPlayerShotPanel, Panel tempPlayerSituationPanel, Panel tempOpponentShotPanel, Panel tempOpponentSituationPanel)
        {
            tempPlayerSituationPanel.Controls[0].Size = new Size(GetStatistics(rallies)[0] * tempPlayerSituationPanel.Width / GetStatistics(rallies)[6], tempPlayerSituationPanel.Height);
            tempPlayerSituationPanel.Controls[1].Size = new Size(GetStatistics(rallies)[1] * tempPlayerSituationPanel.Width / GetStatistics(rallies)[6] + tempPlayerSituationPanel.Controls[0].Size.Width, tempPlayerSituationPanel.Height);
            tempOpponentShotPanel.Controls[0].Size = new Size(GetStatistics(rallies)[0] * tempOpponentShotPanel.Width / GetStatistics(rallies)[6], tempOpponentShotPanel.Height);
            tempOpponentShotPanel.Controls[1].Size = new Size(GetStatistics(rallies)[1] * tempOpponentShotPanel.Width / GetStatistics(rallies)[6] + tempOpponentShotPanel.Controls[0].Size.Width, tempOpponentShotPanel.Height);
            tempPlayerShotPanel.Controls[0].Size = new Size(GetStatistics(rallies)[3] * tempPlayerShotPanel.Width / GetStatistics(rallies)[7], tempPlayerShotPanel.Height);
            tempPlayerShotPanel.Controls[1].Size = new Size(GetStatistics(rallies)[4] * tempPlayerShotPanel.Width / GetStatistics(rallies)[7] + tempPlayerShotPanel.Controls[0].Size.Width, tempPlayerShotPanel.Height);
            tempOpponentSituationPanel.Controls[0].Size = new Size(GetStatistics(rallies)[3] * tempOpponentSituationPanel.Width / GetStatistics(rallies)[7], tempOpponentSituationPanel.Height);
            tempOpponentSituationPanel.Controls[1].Size = new Size(GetStatistics(rallies)[4] * tempOpponentSituationPanel.Width / GetStatistics(rallies)[7] + tempOpponentSituationPanel.Controls[0].Size.Width, tempOpponentSituationPanel.Height);
        }

        //SITUATIONS: offsetPlayerAttacking, offsetPlayerDefending, offsetPlayerNeutral, offsetOpponentAttacking, offsetOpponentDefending, offsetOpponentNeutral, playerTotal, opponentTotal
        private List<int> GetStatistics(List<List<object>> lists)
        {
            int offsetPlayerAttacking = 0;
            int offsetPlayerDefending = 0;
            int offsetPlayerNeutral = 0;
            int offsetOpponentAttacking = 0;
            int offsetOpponentDefending = 0;
            int offsetOpponentNeutral = 0;

            DataFrame df = new DataFrame();
            foreach (List<Object> list in rallies)
            {
                df = list[0] as DataFrame;
                foreach (Object row in df.Rows)
                {
                    DataFrameRow tempRow = row as DataFrameRow;
                    if (tempRow[6].ToString().Contains("Player"))
                    {
                        if (tempRow[5].ToString().Contains("Attacking"))
                        {
                            offsetPlayerAttacking++;
                        } else if (tempRow[5].ToString().Contains("Defending"))
                        {
                            offsetPlayerDefending++;
                        } else if (tempRow[5].ToString().Contains("Neutral"))
                        {
                            offsetPlayerNeutral++;
                        }
                    } else if (tempRow[6].ToString().Contains("Opponent"))
                    {
                        if (tempRow[5].ToString().Contains("Attacking"))
                        {
                            offsetOpponentAttacking++;
                        }
                        else if (tempRow[5].ToString().Contains("Defending"))
                        {
                            offsetOpponentDefending++;
                        }
                        else if (tempRow[5].ToString().Contains("Neutral"))
                        {
                            offsetOpponentNeutral++;
                        }
                    }
                }
            }

            List<int> tempList = new List<int>();
            tempList.Add(offsetPlayerAttacking);
            tempList.Add(offsetPlayerDefending);
            tempList.Add(offsetPlayerNeutral);
            tempList.Add(offsetOpponentAttacking);
            tempList.Add(offsetOpponentDefending);
            tempList.Add(offsetOpponentNeutral);
            tempList.Add(offsetPlayerAttacking + offsetPlayerDefending + offsetPlayerNeutral);
            tempList.Add(offsetOpponentAttacking + offsetOpponentDefending + offsetOpponentNeutral);

            return tempList;
        }

        private void SetFinalShots(FlowLayoutPanel finalPlayerWinningFlowLayoutPanel, FlowLayoutPanel finalPlayerLosingFlowLayoutPanel, FlowLayoutPanel finalOpponentWinningFlowLayoutPanel, FlowLayoutPanel finalOpponentLosingFlowLayoutPanel)
        {
            string playerWinningMessage = "";
            foreach (DictionaryItem dictionaryItem in SortDictionaryItemsDescending(GetFinalShots(rallies)[0]))
            {
                playerWinningMessage += dictionaryItem.Item + ": " + dictionaryItem.Value.ToString() + "\n";
            }

            string playerLosingMessage = "";
            foreach (DictionaryItem dictionaryItem in SortDictionaryItemsDescending(GetFinalShots(rallies)[1]))
            {
                playerLosingMessage += dictionaryItem.Item + ": " + dictionaryItem.Value.ToString() + "\n";
            }

            string opponentWinningMessage = "";
            foreach (DictionaryItem dictionaryItem in SortDictionaryItemsDescending(GetFinalShots(rallies)[2]))
            {
                opponentWinningMessage += dictionaryItem.Item + ": " + dictionaryItem.Value.ToString() + "\n";
            }

            string opponentLosingMessage = "";
            foreach (DictionaryItem dictionaryItem in SortDictionaryItemsDescending(GetFinalShots(rallies)[3]))
            {
                opponentLosingMessage += dictionaryItem.Item + ": " + dictionaryItem.Value.ToString() + "\n";
            }

            finalPlayerWinningFlowLayoutPanel.Controls[0].Text = playerWinningMessage;
            finalPlayerLosingFlowLayoutPanel.Controls[0].Text = playerLosingMessage;
            finalOpponentWinningFlowLayoutPanel.Controls[0].Text = opponentWinningMessage;
            finalOpponentLosingFlowLayoutPanel.Controls[0].Text = opponentLosingMessage;
        }

        private void processSituationButtonClick(Button button)
        {
            situationSelected = true;
            situationButtonSelected = button;
            button.BackColor = SystemColors.ActiveCaption;
            foreach (Button control in button.Parent.Controls)
            {
                if (control != button)
                {
                    control.BackColor = Color.Transparent;
                }
            }
        }

        private List<DictionaryItem> GetCourtStatisticsShotPlayer(List<List<object>> rallyList, string situation, string courtArea)
        {
            int frontLeftCount = 0;
            int frontMiddleCount = 0;
            int frontRightCount = 0;
            int middleLeftCount = 0;
            int middleMiddleCount = 0;
            int middleRightCount = 0;
            int backLeftCount = 0;
            int backMiddleCount = 0;
            int backRightCount = 0;

            DataFrame df = new DataFrame();
            foreach (List<Object> list in rallies)
            {
                df = list[0] as DataFrame;

                foreach (DataFrameRow row in df.Rows)
                {
                    if (row[6].ToString().Contains("Player") && row[5].ToString().Contains(situation) && row[0].ToString().Contains(courtArea))
                    {
                        if (row[1].ToString().Contains("Front Left"))
                        {
                            frontLeftCount++;
                        }
                        else if (row[1].ToString().Contains("Front Middle"))
                        {
                            frontMiddleCount++;
                        }
                        else if(row[1].ToString().Contains("Front Right"))
                        {
                            frontRightCount++;
                        }
                        else if (row[1].ToString().Contains("Middle Left"))
                        {
                            middleLeftCount++;
                        }
                        else if (row[1].ToString().Contains("Middle Middle"))
                        {
                            middleMiddleCount++;
                        }
                        else if (row[1].ToString().Contains("Middle Right"))
                        {
                            middleRightCount++;
                        }
                        else if (row[1].ToString().Contains("Back Left"))
                        {
                            backLeftCount++;
                        }
                        else if (row[1].ToString().Contains("Back Middle"))
                        {
                            backMiddleCount++;
                        }
                        else if (row[1].ToString().Contains("Back Right"))
                        {
                            backRightCount++;
                        }
                    }
                }
            }

            List<DictionaryItem> vs = new List<DictionaryItem>()
            {
                new DictionaryItem() { Item = "Front Left", Value = frontLeftCount },
                new DictionaryItem() { Item = "Front Middle", Value = frontMiddleCount },
                new DictionaryItem() { Item = "Front Right", Value = frontRightCount },
                new DictionaryItem() { Item = "Middle Left", Value = middleLeftCount },
                new DictionaryItem() { Item = "Middle Middle", Value = middleMiddleCount },
                new DictionaryItem() { Item = "Middle Right", Value = middleRightCount },
                new DictionaryItem() { Item = "Back Left", Value = backLeftCount },
                new DictionaryItem() { Item = "Back Middle", Value = backMiddleCount },
                new DictionaryItem() { Item = "Back Right", Value = backRightCount },
            };

            return vs;
        }

        private List<DictionaryItem> GetCourtStatisticsShotOpponent(List<List<object>> rallyList, string situation, string courtArea)
        {
            int frontLeftCount = 0;
            int frontMiddleCount = 0;
            int frontRightCount = 0;
            int middleLeftCount = 0;
            int middleMiddleCount = 0;
            int middleRightCount = 0;
            int backLeftCount = 0;
            int backMiddleCount = 0;
            int backRightCount = 0;

            DataFrame df = new DataFrame();
            foreach (List<Object> list in rallies)
            {
                df = list[0] as DataFrame;

                foreach (DataFrameRow row in df.Rows)
                {
                    if (row[6].ToString().Contains("Opponent") && row[5].ToString().Contains(situation) && row[0].ToString().Contains(courtArea))
                    {
                        if (row[1].ToString().Contains("Front Left"))
                        {
                            frontLeftCount++;
                        }
                        else if (row[1].ToString().Contains("Front Middle"))
                        {
                            frontMiddleCount++;
                        }
                        else if (row[1].ToString().Contains("Front Right"))
                        {
                            frontRightCount++;
                        }
                        else if (row[1].ToString().Contains("Middle Left"))
                        {
                            middleLeftCount++;
                        }
                        else if (row[1].ToString().Contains("Middle Middle"))
                        {
                            middleMiddleCount++;
                        }
                        else if (row[1].ToString().Contains("Middle Right"))
                        {
                            middleRightCount++;
                        }
                        else if (row[1].ToString().Contains("Back Left"))
                        {
                            backLeftCount++;
                        }
                        else if (row[1].ToString().Contains("Back Middle"))
                        {
                            backMiddleCount++;
                        }
                        else if (row[1].ToString().Contains("Back Right"))
                        {
                            backRightCount++;
                        }
                    }
                }
            }

            List<DictionaryItem> vs = new List<DictionaryItem>()
            {
                new DictionaryItem() { Item = "Front Left", Value = frontLeftCount },
                new DictionaryItem() { Item = "Front Middle", Value = frontMiddleCount },
                new DictionaryItem() { Item = "Front Right", Value = frontRightCount },
                new DictionaryItem() { Item = "Middle Left", Value = middleLeftCount },
                new DictionaryItem() { Item = "Middle Middle", Value = middleMiddleCount },
                new DictionaryItem() { Item = "Middle Right", Value = middleRightCount },
                new DictionaryItem() { Item = "Back Left", Value = backLeftCount },
                new DictionaryItem() { Item = "Back Middle", Value = backMiddleCount },
                new DictionaryItem() { Item = "Back Right", Value = backRightCount },
            };

            return vs;
        }


        private void HandleCourtStatisticsShot()
        {
            if (situationSelected == false)
            {
                return;
            }

            if (LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)).Y > courtPictureBox1.Height / 2)
            {
                List<DictionaryItem> dictionaryItems = new List<DictionaryItem>();
                foreach (var (item, index) in GetCourtStatisticsShotPlayer(rallies, situationButtonSelected.Text, frm1.GetAreaOnCourtPlayer(LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), courtPictureBox1)).WithIndex())
                {
                    dictionaryItems.Add(GetCourtStatisticsShotPlayer(rallies, situationButtonSelected.Text, frm1.GetAreaOnCourtPlayer(LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), courtPictureBox1))[index]);
                }

                List<DictionaryItem> dictionaryItemsSorted = SortDictionaryItemsDescending(dictionaryItems);

                string message = "Player:\n";
                foreach (DictionaryItem item in dictionaryItemsSorted)
                {
                    message += item.Item + ": " + item.Value + "\n";
                }

                commonShotLabel.Text = message;

                HandleEndPictureBoxLocationsPlayer(dictionaryItemsSorted, endBigPictureBox, endMediumPictureBox, endSmallPictureBox);
            }
            else if (LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)).Y <= courtPictureBox1.Height / 2)
            {
                List<DictionaryItem> dictionaryItems = new List<DictionaryItem>();
                foreach (var (item, index) in GetCourtStatisticsShotOpponent(rallies, situationButtonSelected.Text, frm1.GetAreaOnCourtOpponent(LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), courtPictureBox1)).WithIndex())
                {
                    dictionaryItems.Add(GetCourtStatisticsShotOpponent(rallies, situationButtonSelected.Text, frm1.GetAreaOnCourtOpponent(LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), courtPictureBox1))[index]);
                }

                List<DictionaryItem> dictionaryItemsSorted = SortDictionaryItemsDescending(dictionaryItems);

                string message = "Opponent:\n";
                foreach (DictionaryItem item in dictionaryItemsSorted)
                {
                    message += item.Item + ": " + item.Value + "\n";
                }

                commonShotLabel.Text = message;

                HandleEndPictureBoxLocationsOpponent(dictionaryItemsSorted, endBigPictureBox, endMediumPictureBox, endSmallPictureBox);
            }
        }

        private Point GetPointFromAreaOpponent(string courtArea, PictureBox court)
        {
            Point point = new Point(0, 0);
            if (courtArea.Contains("Front Left"))
            {
                point = new Point((int)(court.Width * 0.15), (int)(court.Height * 0.6));
            }
            else if (courtArea.Contains("Front Middle"))
            {
                point = new Point((int)(court.Width * 0.5), (int)(court.Height * 0.6));
            }
            else if (courtArea.Contains("Front Right"))
            {
                point = new Point((int)(court.Width * 0.85), (int)(court.Height * 0.6));
            }

            else if (courtArea.Contains("Middle Left"))
            {
                point = new Point((int)(court.Width * 0.15), (int)(court.Height * 0.8));
            }
            else if (courtArea.Contains("Middle Middle"))
            {
                point = new Point((int)(court.Width * 0.5), (int)(court.Height * 0.8));
            }
            else if (courtArea.Contains("Middle Right"))
            {
                point = new Point((int)(court.Width * 0.85), (int)(court.Height * 0.8));
            }

            else if (courtArea.Contains("Back Left"))
            {
                point = new Point((int)(court.Width * 0.15), (int)(court.Height * 0.95));
            }
            else if (courtArea.Contains("Back Middle"))
            {
                point = new Point((int)(court.Width * 0.5), (int)(court.Height * 0.95));
            }
            else if (courtArea.Contains("Back Right"))
            {
                point = new Point((int)(court.Width * 0.85), (int)(court.Height * 0.95));
            }

            return point;
        }

        private Point GetPointFromAreaPlayer(string courtArea, PictureBox court)
        {
            Point point = new Point(0, 0);
            if (courtArea.Contains("Front Left"))
            {
                point = new Point((int)(court.Width * 0.85), (int)(court.Height * 0.4));
            }
            else if (courtArea.Contains("Front Middle"))
            {
                point = new Point((int)(court.Width * 0.5), (int)(court.Height * 0.4));
            }
            else if (courtArea.Contains("Front Right"))
            {
                point = new Point((int)(court.Width * 0.15), (int)(court.Height * 0.4));
            }

            else if (courtArea.Contains("Middle Left"))
            {
                point = new Point((int)(court.Width * 0.85), (int)(court.Height * 0.2));
            }
            else if (courtArea.Contains("Middle Middle"))
            {
                point = new Point((int)(court.Width * 0.5), (int)(court.Height * 0.2));
            }
            else if (courtArea.Contains("Middle Right"))
            {
                point = new Point((int)(court.Width * 0.15), (int)(court.Height * 0.2));
            }

            else if (courtArea.Contains("Back Left"))
            {
                point = new Point((int)(court.Width * 0.85), (int)(court.Height * 0.05));
            }
            else if (courtArea.Contains("Back Middle"))
            {
                point = new Point((int)(court.Width * 0.5), (int)(court.Height * 0.05));
            }
            else if (courtArea.Contains("Back Right"))
            {
                point = new Point((int)(court.Width * 0.15), (int)(court.Height * 0.05));
            }

            return point;
        }


        private void HandleEndPictureBoxLocationsPlayer(List<DictionaryItem> sortedList, PictureBox bigPictureBox, PictureBox mediumPictureBox, PictureBox smallPictureBox)
        {
            if (situationSelected == false)
            {
                return;
            }

            if (sortedList[0].Value == 0)
            {
                bigPictureBox.Location = new Point(-24, -24);
            } else
            {
                bigPictureBox.Location = LocationOffsetPoint(GetPointFromAreaPlayer(sortedList[0].Item, courtPictureBox1), new Point(-bigPictureBox.Width / 2, -bigPictureBox.Height / 2));
            }

            if (sortedList[1].Value == 0)
            {
                mediumPictureBox.Location = new Point(-24, -24);
            }
            else
            {
                mediumPictureBox.Location = LocationOffsetPoint(GetPointFromAreaPlayer(sortedList[1].Item, courtPictureBox1), new Point(-mediumPictureBox.Width / 2, -mediumPictureBox.Height / 2));
            }

            if (sortedList[2].Value == 0)
            {
                smallPictureBox.Location = new Point(-24, -24);
            }
            else
            {
                smallPictureBox.Location = LocationOffsetPoint(GetPointFromAreaPlayer(sortedList[2].Item, courtPictureBox1), new Point(-smallPictureBox.Width / 2, -smallPictureBox.Height / 2));
            }
        }

        private void HandleEndPictureBoxLocationsOpponent(List<DictionaryItem> sortedList, PictureBox bigPictureBox, PictureBox mediumPictureBox, PictureBox smallPictureBox)
        {
            if (situationSelected == false)
            {
                return;
            }

            if (sortedList[0].Value == 0)
            {
                bigPictureBox.Location = new Point(-24, -24);
            }
            else
            {
                bigPictureBox.Location = LocationOffsetPoint(GetPointFromAreaOpponent(sortedList[0].Item, courtPictureBox1), new Point(-bigPictureBox.Width / 2, -bigPictureBox.Height / 2));
            }

            if (sortedList[1].Value == 0)
            {
                mediumPictureBox.Location = new Point(-24, -24);
            }
            else
            {
                mediumPictureBox.Location = LocationOffsetPoint(GetPointFromAreaOpponent(sortedList[1].Item, courtPictureBox1), new Point(-mediumPictureBox.Width / 2, -mediumPictureBox.Height / 2));
            }

            if (sortedList[2].Value == 0)
            {
                smallPictureBox.Location = new Point(-24, -24);
            }
            else
            {
                smallPictureBox.Location = LocationOffsetPoint(GetPointFromAreaOpponent(sortedList[2].Item, courtPictureBox1), new Point(-smallPictureBox.Width / 2, -smallPictureBox.Height / 2));
            }
        }


        private void HandleCourtStatisticsShotInOut()
        {
            if (situationSelected == false)
            {
                return;
            }

            commonShotOutcome.Controls[0].Hide();

            if (LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)).Y > courtPictureBox1.Height / 2)
            {
                try
                {
                    commonShotOutcome.Controls[1].Size = new Size(GetCourtStatisticsShotInOutPlayer(rallies, situationButtonSelected.Text, frm1.GetAreaOnCourtPlayer(LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), courtPictureBox1))[0].Value * commonShotOutcome.Width / GetCourtStatisticsShotInOutPlayer(rallies, situationButtonSelected.Text, frm1.GetAreaOnCourtPlayer(LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), courtPictureBox1))[2].Value, commonShotOutcome.Height);
                } catch (ArithmeticException ex)
                {
                    commonShotOutcome.Controls[0].Show();
                }
                
            }
            else if (LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)).Y <= courtPictureBox1.Height / 2)
            {
                try
                {
                    commonShotOutcome.Controls[1].Size = new Size(GetCourtStatisticsShotInOutOpponent(rallies, situationButtonSelected.Text, frm1.GetAreaOnCourtOpponent(LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), courtPictureBox1))[0].Value * commonShotOutcome.Width / GetCourtStatisticsShotInOutOpponent(rallies, situationButtonSelected.Text, frm1.GetAreaOnCourtOpponent(LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), courtPictureBox1))[2].Value, commonShotOutcome.Height);
                } catch (ArithmeticException ex)
                {
                    commonShotOutcome.Controls[0].Show();
                }
            }
        }

        private List<DictionaryItem> GetCourtStatisticsRallyOutcomePlayer(List<List<Object>> rallyList, string situation, string courtArea)
        {
            int winCount = 0;
            int loseCount = 0;

            DataFrame df = new DataFrame();

            foreach (List<Object> list in rallies)
            {
                df = list[0] as DataFrame;

                foreach (var (row, index) in df.Rows.WithIndex())
                {
                    if (row[6].ToString().Contains("Player") && row[5].ToString().Contains(situation) && row[0].ToString().Contains(courtArea))
                    {
                        if (list[1].ToString().Contains("Player"))
                        {
                            winCount++;
                        } else if (list[1].ToString().Contains("Opponent"))
                        {
                            loseCount++;
                        }
                    }
                }
            }

            List<DictionaryItem> vs = new List<DictionaryItem>()
            {
                new DictionaryItem() { Item = "Win", Value = winCount },
                new DictionaryItem() { Item = "Lose", Value = loseCount },
                new DictionaryItem() { Item = "Total", Value = winCount + loseCount }
            };


            return vs;
        }

        private List<DictionaryItem> GetCourtStatisticsRallyOutcomeOpponent(List<List<Object>> rallyList, string situation, string courtArea)
        {
            int winCount = 0;
            int loseCount = 0;

            DataFrame df = new DataFrame();

            foreach (List<Object> list in rallies)
            {
                df = list[0] as DataFrame;

                foreach (var (row, index) in df.Rows.WithIndex())
                {
                    if (row[6].ToString().Contains("Opponent") && row[5].ToString().Contains(situation) && row[0].ToString().Contains(courtArea))
                    {
                        if (list[1].ToString().Contains("Opponent"))
                        {
                            winCount++;
                        }
                        else if (list[1].ToString().Contains("Player"))
                        {
                            loseCount++;
                        }
                    }
                }
            }

            List<DictionaryItem> vs = new List<DictionaryItem>()
            {
                new DictionaryItem() { Item = "Win", Value = winCount },
                new DictionaryItem() { Item = "Lose", Value = loseCount },
                new DictionaryItem() { Item = "Total", Value = winCount + loseCount }
            };


            return vs;
        }

        private void HandleCourtStatisticsRallyOutcome()
        {
            if (situationSelected == false)
            {
                return;
            }

            commonRallyOutcome.Controls[0].Hide();

            if (LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)).Y > courtPictureBox1.Height / 2)
            {
                try
                {
                    commonRallyOutcome.Controls[1].Size = new Size(GetCourtStatisticsRallyOutcomePlayer(rallies, situationButtonSelected.Text, frm1.GetAreaOnCourtPlayer(LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), courtPictureBox1))[0].Value * commonShotOutcome.Width / GetCourtStatisticsRallyOutcomePlayer(rallies, situationButtonSelected.Text, frm1.GetAreaOnCourtPlayer(LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), courtPictureBox1))[2].Value, commonRallyOutcome.Height);
                }
                catch (ArithmeticException ex)
                {
                    commonRallyOutcome.Controls[0].Show();
                }

            }
            else if (LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)).Y <= courtPictureBox1.Height / 2)
            {
                try
                {
                    commonRallyOutcome.Controls[1].Size = new Size(GetCourtStatisticsRallyOutcomeOpponent(rallies, situationButtonSelected.Text, frm1.GetAreaOnCourtOpponent(LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), courtPictureBox1))[0].Value * commonShotOutcome.Width / GetCourtStatisticsRallyOutcomeOpponent(rallies, situationButtonSelected.Text, frm1.GetAreaOnCourtOpponent(LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), courtPictureBox1))[2].Value, commonRallyOutcome.Height);
                }
                catch (ArithmeticException ex)
                {
                    commonRallyOutcome.Controls[0].Show();
                }
            }
        }

        private List<DictionaryItem> GetCourtStatisticsShotInOutPlayer(List<List<Object>> rallyList, string situation, string courtArea)
        {
            int inCount = 0;
            int outCount = 0;
            DataFrame df = new DataFrame();

            foreach (List<Object> list in rallies)
            {
                df = list[0] as DataFrame;

                foreach (var (row, index) in df.Rows.WithIndex())
                {
                    if (row[6].ToString().Contains("Player") && row[5].ToString().Contains(situation) && row[0].ToString().Contains(courtArea))
                    {
                        if (index == (df.Rows.Count - 1) && list[1].ToString().Contains("Opponent"))
                        {
                            outCount++;
                        } else
                        {
                            inCount++;
                        }
                    }
                }
            }

            List<DictionaryItem> vs = new List<DictionaryItem>()
            {
                new DictionaryItem() { Item = "In", Value = inCount },
                new DictionaryItem() { Item = "Out", Value = outCount },
                new DictionaryItem() { Item = "Total", Value = inCount + outCount }
            };

            Debug.WriteLine("In count: " + inCount + ", out count: " + outCount + ", total: " + (inCount + outCount));

            return vs;
        }

        private List<DictionaryItem> GetCourtStatisticsShotInOutOpponent(List<List<Object>> rallyList, string situation, string courtArea)
        {
            int inCount = 0;
            int outCount = 0;
            DataFrame df = new DataFrame();

            foreach (List<Object> list in rallies)
            {
                df = list[0] as DataFrame;

                foreach (var (row, index) in df.Rows.WithIndex())
                {
                    if (row[6].ToString().Contains("Opponent") && row[5].ToString().Contains(situation) && row[0].ToString().Contains(courtArea))
                    {
                        if (index == (df.Rows.Count - 1) && list[1].ToString().Contains("Player"))
                        {
                            outCount++;
                        }
                        else
                        {
                            inCount++;
                        }
                    }
                }
            }

            List<DictionaryItem> vs = new List<DictionaryItem>()
            {
                new DictionaryItem() { Item = "In", Value = inCount },
                new DictionaryItem() { Item = "Out", Value = outCount },
                new DictionaryItem() { Item = "Total", Value = inCount + outCount }
            };

            Debug.WriteLine("In count: " + inCount + ", out count: " + outCount + ", total: " + (inCount + outCount));

            return vs;
        }

        private List<List<DictionaryItem>> GetFinalShots(List<List<object>> tempRallies)
        {
            int playerFlatClearWinningCount = 0;
            int playerHighClearWinningCount = 0;
            int playerFastDropWinningCount = 0;
            int playerSlowDropWinningCount = 0;
            int playerHalfSmashWinningCount = 0;
            int playerFullSmashWinningCount = 0;
            int playerCloseNetWinningCount = 0;
            int playerFarNetWinningCount = 0;
            int playerNetSpinWinningCount = 0;
            int playerCrossNetWinningCount = 0;
            int playerLiftWinningCount = 0;
            int playerPushWinningCount = 0;
            int playerCloseBlockWinningCount = 0;
            int playerFarBlockWinningCount = 0;
            int playerLowServeWinningCount = 0;
            int playerHighServeWinningCount = 0;

            int playerFlatClearLosingCount = 0;
            int playerHighClearLosingCount = 0;
            int playerFastDropLosingCount = 0;
            int playerSlowDropLosingCount = 0;
            int playerHalfSmashLosingCount = 0;
            int playerFullSmashLosingCount = 0;
            int playerCloseNetLosingCount = 0;
            int playerFarNetLosingCount = 0;
            int playerNetSpinLosingCount = 0;
            int playerCrossNetLosingCount = 0;
            int playerLiftLosingCount = 0;
            int playerPushLosingCount = 0;
            int playerCloseBlockLosingCount = 0;
            int playerFarBlockLosingCount = 0;
            int playerLowServeLosingCount = 0;
            int playerHighServeLosingCount = 0;

            int opponentFlatClearWinningCount = 0;
            int opponentHighClearWinningCount = 0;
            int opponentFastDropWinningCount = 0;
            int opponentSlowDropWinningCount = 0;
            int opponentHalfSmashWinningCount = 0;
            int opponentFullSmashWinningCount = 0;
            int opponentCloseNetWinningCount = 0;
            int opponentFarNetWinningCount = 0;
            int opponentNetSpinWinningCount = 0;
            int opponentCrossNetWinningCount = 0;
            int opponentLiftWinningCount = 0;
            int opponentPushWinningCount = 0;
            int opponentCloseBlockWinningCount = 0;
            int opponentFarBlockWinningCount = 0;
            int opponentLowServeWinningCount = 0;
            int opponentHighServeWinningCount = 0;

            int opponentFlatClearLosingCount = 0;
            int opponentHighClearLosingCount = 0;
            int opponentFastDropLosingCount = 0;
            int opponentSlowDropLosingCount = 0;
            int opponentHalfSmashLosingCount = 0;
            int opponentFullSmashLosingCount = 0;
            int opponentCloseNetLosingCount = 0;
            int opponentFarNetLosingCount = 0;
            int opponentNetSpinLosingCount = 0;
            int opponentCrossNetLosingCount = 0;
            int opponentLiftLosingCount = 0;
            int opponentPushLosingCount = 0;
            int opponentCloseBlockLosingCount = 0;
            int opponentFarBlockLosingCount = 0;
            int opponentLowServeLosingCount = 0;
            int opponentHighServeLosingCount = 0;

            DataFrame df = new DataFrame();
            foreach (List<Object> list in tempRallies)
            {
                df = list[0] as DataFrame;
                if (list[1].ToString().Contains("Player"))
                {
                    for (int i = 1; i <= df.Rows.Count; i++)
                    {
                        if (df.Rows[df.Rows.Count - i][6].ToString().Contains("Player"))
                        {
                            if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Flat Clear"))
                            {
                                playerFlatClearWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("High Clear"))
                            {
                                playerHighClearWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Fast Drop"))
                            {
                                playerFastDropWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Slow Drop"))
                            {
                                playerSlowDropWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Half Smash"))
                            {
                                playerHalfSmashWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Full Smash"))
                            {
                                playerFullSmashWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Close Net"))
                            {
                                playerCloseNetWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Far Net"))
                            {
                                playerFarNetWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Net Spin"))
                            {
                                playerNetSpinWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Cross Net"))
                            {
                                playerCrossNetWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Lift"))
                            {
                                playerLiftWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Push"))
                            {
                                playerPushWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Close Block"))
                            {
                                playerCloseBlockWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Far Block"))
                            {
                                playerFarBlockWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Low Serve"))
                            {
                                playerLowServeWinningCount++;
                            } else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("High Serve"))
                            {
                                playerHighServeWinningCount++;
                            }
                            break;
                        }
                    }

                    for (int i = 1; i <= df.Rows.Count; i++)
                    {
                        if (df.Rows[df.Rows.Count - i][6].ToString().Contains("Opponent"))
                        {
                            if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Flat Clear"))
                            {
                                opponentFlatClearLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("High Clear"))
                            {
                                opponentHighClearLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Fast Drop"))
                            {
                                opponentFastDropLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Slow Drop"))
                            {
                                opponentSlowDropLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Half Smash"))
                            {
                                opponentHalfSmashLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Full Smash"))
                            {
                                opponentFullSmashLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Close Net"))
                            {
                                opponentCloseNetLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Far Net"))
                            {
                                opponentFarNetLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Net Spin"))
                            {
                                opponentNetSpinLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Cross Net"))
                            {
                                opponentCrossNetLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Lift"))
                            {
                                opponentLiftLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Push"))
                            {
                                opponentPushLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Close Block"))
                            {
                                opponentCloseBlockLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Far Block"))
                            {
                                opponentFarBlockLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Low Serve"))
                            {
                                opponentLowServeLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("High Serve"))
                            {
                                opponentHighServeLosingCount++;
                            }
                            break;
                        }
                    }
                } else if (list[1].ToString().Contains("Opponent"))
                {
                    for (int i = 1; i <= df.Rows.Count; i++)
                    {
                        if (df.Rows[df.Rows.Count - i][6].ToString().Contains("Player"))
                        {
                            if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Flat Clear"))
                            {
                                playerFlatClearLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("High Clear"))
                            {
                                playerHighClearLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Fast Drop"))
                            {
                                playerFastDropLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Slow Drop"))
                            {
                                playerSlowDropLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Half Smash"))
                            {
                                playerHalfSmashLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Full Smash"))
                            {
                                playerFullSmashLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Close Net"))
                            {
                                playerCloseNetLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Far Net"))
                            {
                                playerFarNetLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Net Spin"))
                            {
                                playerNetSpinLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Cross Net"))
                            {
                                playerCrossNetLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Lift"))
                            {
                                playerLiftLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Push"))
                            {
                                playerPushLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Close Block"))
                            {
                                playerCloseBlockLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Far Block"))
                            {
                                playerFarBlockLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Low Serve"))
                            {
                                playerLowServeLosingCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("High Serve"))
                            {
                                playerHighServeLosingCount++;
                            }
                            break;
                        }
                    }

                    for (int i = 1; i <= df.Rows.Count; i++)
                    {
                        if (df.Rows[df.Rows.Count - i][6].ToString().Contains("Opponent"))
                        {
                            if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Flat Clear"))
                            {
                                opponentFlatClearWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("High Clear"))
                            {
                                opponentHighClearWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Fast Drop"))
                            {
                                opponentFastDropWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Slow Drop"))
                            {
                                opponentSlowDropWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Half Smash"))
                            {
                                opponentHalfSmashWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Full Smash"))
                            {
                                opponentFullSmashWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Close Net"))
                            {
                                opponentCloseNetWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Far Net"))
                            {
                                opponentFarNetWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Net Spin"))
                            {
                                opponentNetSpinWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Cross Net"))
                            {
                                opponentCrossNetWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Lift"))
                            {
                                opponentLiftWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Push"))
                            {
                                opponentPushWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Close Block"))
                            {
                                opponentCloseBlockWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Far Block"))
                            {
                                opponentFarBlockWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("Low Serve"))
                            {
                                opponentLowServeWinningCount++;
                            }
                            else if (df.Rows[df.Rows.Count - i][4].ToString().Contains("High Serve"))
                            {
                                opponentHighServeWinningCount++;
                            }
                            break;
                        }
                    }
                }
            }

            List<DictionaryItem> playerWinningList = new List<DictionaryItem>()
            {
                new DictionaryItem() { Item = "Flat Clear", Value = playerFlatClearWinningCount },
                new DictionaryItem() { Item = "High Clear", Value = playerHighClearWinningCount },
                new DictionaryItem() { Item = "Fast Drop", Value = playerFastDropWinningCount },
                new DictionaryItem() { Item = "Slow Drop", Value = playerSlowDropWinningCount },
                new DictionaryItem() { Item = "Half Smash", Value = playerHalfSmashWinningCount },
                new DictionaryItem() { Item = "Full Smash", Value = playerFullSmashWinningCount },
                new DictionaryItem() { Item = "Close Net", Value = playerCloseNetWinningCount },
                new DictionaryItem() { Item = "Far Net", Value = playerFarNetWinningCount },
                new DictionaryItem() { Item = "Net Spin", Value = playerNetSpinWinningCount },
                new DictionaryItem() { Item = "Cross Net", Value = playerCrossNetWinningCount },
                new DictionaryItem() { Item = "Lift", Value = playerLiftWinningCount },
                new DictionaryItem() { Item = "Push", Value = playerPushWinningCount },
                new DictionaryItem() { Item = "Close Block", Value = playerCloseBlockWinningCount },
                new DictionaryItem() { Item = "Far Block", Value = playerFarBlockWinningCount },
                new DictionaryItem() { Item = "Low Serve", Value = playerLowServeWinningCount },
                new DictionaryItem() { Item = "High Serve", Value = playerHighServeWinningCount }
            };

            List<DictionaryItem> playerLosingList = new List<DictionaryItem>()
            {
                new DictionaryItem() { Item = "Flat Clear", Value = playerFlatClearLosingCount },
                new DictionaryItem() { Item = "High Clear", Value = playerHighClearLosingCount },
                new DictionaryItem() { Item = "Fast Drop", Value = playerFastDropLosingCount },
                new DictionaryItem() { Item = "Slow Drop", Value = playerSlowDropLosingCount },
                new DictionaryItem() { Item = "Half Smash", Value = playerHalfSmashLosingCount },
                new DictionaryItem() { Item = "Full Smash", Value = playerFullSmashLosingCount },
                new DictionaryItem() { Item = "Close Net", Value = playerCloseNetLosingCount },
                new DictionaryItem() { Item = "Far Net", Value = playerFarNetLosingCount },
                new DictionaryItem() { Item = "Net Spin", Value = playerNetSpinLosingCount },
                new DictionaryItem() { Item = "Cross Net", Value = playerCrossNetLosingCount },
                new DictionaryItem() { Item = "Lift", Value = playerLiftLosingCount },
                new DictionaryItem() { Item = "Push", Value = playerPushLosingCount },
                new DictionaryItem() { Item = "Close Block", Value = playerCloseBlockLosingCount },
                new DictionaryItem() { Item = "Far Block", Value = playerFarBlockLosingCount },
                new DictionaryItem() { Item = "Low Serve", Value = playerLowServeLosingCount },
                new DictionaryItem() { Item = "High Serve", Value = playerHighServeLosingCount }
            };

            List<DictionaryItem> opponentWinningList = new List<DictionaryItem>()
            {
                new DictionaryItem() { Item = "Flat Clear", Value = opponentFlatClearWinningCount },
                new DictionaryItem() { Item = "High Clear", Value = opponentHighClearWinningCount },
                new DictionaryItem() { Item = "Fast Drop", Value = opponentFastDropWinningCount },
                new DictionaryItem() { Item = "Slow Drop", Value = opponentSlowDropWinningCount },
                new DictionaryItem() { Item = "Half Smash", Value = opponentHalfSmashWinningCount },
                new DictionaryItem() { Item = "Full Smash", Value = opponentFullSmashWinningCount },
                new DictionaryItem() { Item = "Close Net", Value = opponentCloseNetWinningCount },
                new DictionaryItem() { Item = "Far Net", Value = opponentFarNetWinningCount },
                new DictionaryItem() { Item = "Net Spin", Value = opponentNetSpinWinningCount },
                new DictionaryItem() { Item = "Cross Net", Value = opponentCrossNetWinningCount },
                new DictionaryItem() { Item = "Lift", Value = opponentLiftWinningCount },
                new DictionaryItem() { Item = "Push", Value = opponentPushWinningCount },
                new DictionaryItem() { Item = "Close Block", Value = opponentCloseBlockWinningCount },
                new DictionaryItem() { Item = "Far Block", Value = opponentFarBlockWinningCount },
                new DictionaryItem() { Item = "Low Serve", Value = opponentLowServeWinningCount },
                new DictionaryItem() { Item = "High Serve", Value = opponentHighServeWinningCount }
            };

            List<DictionaryItem> opponentLosingList = new List<DictionaryItem>()
            {
                new DictionaryItem() { Item = "Flat Clear", Value = opponentFlatClearLosingCount },
                new DictionaryItem() { Item = "High Clear", Value = opponentHighClearLosingCount },
                new DictionaryItem() { Item = "Fast Drop", Value = opponentFastDropLosingCount },
                new DictionaryItem() { Item = "Slow Drop", Value = opponentSlowDropLosingCount },
                new DictionaryItem() { Item = "Half Smash", Value = opponentHalfSmashLosingCount },
                new DictionaryItem() { Item = "Full Smash", Value = opponentFullSmashLosingCount },
                new DictionaryItem() { Item = "Close Net", Value = opponentCloseNetLosingCount },
                new DictionaryItem() { Item = "Far Net", Value = opponentFarNetLosingCount },
                new DictionaryItem() { Item = "Net Spin", Value = opponentNetSpinLosingCount },
                new DictionaryItem() { Item = "Cross Net", Value = opponentCrossNetLosingCount },
                new DictionaryItem() { Item = "Lift", Value = opponentLiftLosingCount },
                new DictionaryItem() { Item = "Push", Value = opponentPushLosingCount },
                new DictionaryItem() { Item = "Close Block", Value = opponentCloseBlockLosingCount },
                new DictionaryItem() { Item = "Far Block", Value = opponentFarBlockLosingCount },
                new DictionaryItem() { Item = "Low Serve", Value = opponentLowServeLosingCount },
                new DictionaryItem() { Item = "High Serve", Value = opponentHighServeLosingCount }
            };

            return new List<List<DictionaryItem>>() { playerWinningList, playerLosingList, opponentWinningList, opponentLosingList };
        }

        private List<DictionaryItem> SortDictionaryItemsDescending(List<DictionaryItem> list)
        {
            return list.OrderByDescending(x => x.Value).ToList();
        }
        private List<DictionaryItem> SortFinalShotsAsStringDescending(List<List<string>> list)
        {
            List<DictionaryItem> tempList = new List<DictionaryItem>();
            foreach (List<string> vs in list)
            {
                tempList.Add(new DictionaryItem() { Item = vs[0], Value = int.Parse(vs[1]) });
            }
            return tempList.OrderByDescending(x => x.Value).ToList();
        }


        private List<List<string>> SortShots(List<string> shotsAsTypes)
        {
            int flatClearCount = 0;
            int highClearCount = 0;
            int fastDropCount = 0;
            int slowDropCount = 0;
            int halfSmashCount = 0;
            int fullSmashCount = 0;
            int closeNetCount = 0;
            int farNetCount = 0;
            int netSpinCount = 0;
            int crossNetCount = 0;
            int liftCount = 0;
            int pushCount = 0;
            int closeBlockCount = 0;
            int farBlockCount = 0;
            int lowServeCount = 0;
            int highServeCount = 0;
            foreach (object shotType in shotsAsTypes)
            {
                if (shotType.ToString() == "Flat Clear")
                {
                    flatClearCount++;
                } else if (shotType.ToString() == "High Clear")
                {
                    highClearCount++;
                }
                else if (shotType.ToString() == "Fast Drop")
                {
                    fastDropCount++;
                }
                else if (shotType.ToString() == "Slow Drop")
                {
                    slowDropCount++;
                }
                else if (shotType.ToString() == "Half Smash")
                {
                    halfSmashCount++;
                }
                else if (shotType.ToString() == "Full Smash")
                {
                    fullSmashCount++;
                }
                else if (shotType.ToString() == "Close Net")
                {
                    closeNetCount++;
                }
                else if (shotType.ToString() == "Far Net")
                {
                    farNetCount++;
                }
                else if (shotType.ToString() == "Net Spin")
                {
                    netSpinCount++;
                }
                else if (shotType.ToString() == "Cross Net")
                {
                    crossNetCount++;
                }
                else if (shotType.ToString() == "Lift")
                {
                    liftCount++;
                }
                else if (shotType.ToString() == "Push")
                {
                    pushCount++;
                }
                else if (shotType.ToString() == "Close Block")
                {
                    closeBlockCount++;
                }
                else if (shotType.ToString() == "Far Block")
                {
                    farBlockCount++;
                }
                else if (shotType.ToString() == "Low Serve")
                {
                    lowServeCount++;
                }
                else if (shotType.ToString() == "High Serve")
                {
                    highServeCount++;
                }
            }

            IList<Shot> shotTypeList = new List<Shot>()
            {
                new Shot() { Type = "Flat Clear", Amount = flatClearCount},
                new Shot() { Type = "High Clear", Amount = highClearCount},
                new Shot() { Type = "Fast Drop", Amount = fastDropCount},
                new Shot() { Type = "Slow Drop", Amount = slowDropCount},
                new Shot() { Type = "Half Smash", Amount = halfSmashCount},
                new Shot() { Type = "Full Smash", Amount = fullSmashCount},
                new Shot() { Type = "Close Net", Amount = closeNetCount},
                new Shot() { Type = "Far Net", Amount = farNetCount},
                new Shot() { Type = "Net Spin", Amount = netSpinCount},
                new Shot() { Type = "Cross Net", Amount = crossNetCount},
                new Shot() { Type = "Lift", Amount = liftCount},
                new Shot() { Type = "Push", Amount = pushCount},
                new Shot() { Type = "Close Block", Amount = closeBlockCount},
                new Shot() { Type = "Far Block", Amount = farBlockCount},
                new Shot() { Type = "Low Serve", Amount = lowServeCount},
                new Shot() { Type = "High Serve", Amount = highServeCount}
            };

            List<Shot> shotTypeListSorted = shotTypeList.OrderByDescending(x => x.Amount).ToList();

            List<List<string>> shotTypeListSortedAsString = new List<List<string>>();

            foreach (Shot shot in shotTypeListSorted)
            {
                shotTypeListSortedAsString.Add(new List<string>() { shot.Type , shot.Amount.ToString() });
            }

            return shotTypeListSortedAsString;
        }

        private Point LocationOffsetPoint(Point location, Point offset)
        {
            location.Offset(offset.X, offset.Y);
            return location;
        }

        private void LoadChart1()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chartArea1.AxisY.Interval = 1;
            chartArea1.AxisX.Minimum = 0;
            chartArea1.AxisX.MinorTickMark.Interval = 1;
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();

            List<int> playerScore = new List<int>() { 0 };
            List<int> opponentScore = new List<int>() { 0 };
            List<int> xList = new List<int>() { 0 };

            for (int i = 0; i < rallies.Count; i++)
            {
                playerScore.Add(GetScore(rallies, i + 1).Item1);
                opponentScore.Add(GetScore(rallies, i + 1).Item2);
                xList.Add(i + 1);
            }

            Chart chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart()
            {
                Location = new Point(3, 3),
                Size = new Size(634, 570),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
            };

            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);

            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);


            chart1.Series.Clear();

            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Player",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = true,
                BorderWidth = 3,
                ChartType = SeriesChartType.Line
            };

            var series2 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Opponent",
                Color = System.Drawing.Color.Red,
                IsVisibleInLegend = true,
                BorderWidth = 3,
                ChartType = SeriesChartType.Line
            };

            chart1.Series.Add(series1);
            chart1.Series.Add(series2);

            chart1.Series[0].Points.DataBindXY(xList, playerScore);
            chart1.Series[1].Points.DataBindXY(xList, opponentScore);

            chart1.Invalidate();

            tabPage4.Controls.Add(chart1);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (frm1 != null)
            {
                rallies = frm1.rallies;

                LoadChart1();

                shotTypeLabel.Text = GetShot((int)rallyUpDown.Value, (int)shotUpDown.Value)[6] + "\n" + GetShot((int)rallyUpDown.Value, (int)shotUpDown.Value)[5] + "\n" + GetShotType((int)rallyUpDown.Value, (int)shotUpDown.Value);

                scoreLabel.Text = GetScore(rallies, rallies.Count).Item1 + " : " + GetScore(rallies, rallies.Count).Item2;

                rallyUpDown.Maximum = rallies.Count;
                DataFrame shotCountFrame = rallies[(int)rallyUpDown.Value - 1][0] as DataFrame;
                long shotCount = shotCountFrame.Rows.Count;
                shotUpDown.Maximum = shotCount;

                startPictureBox.Location = LocationOffsetPoint(GetShotLocation((int)rallyUpDown.Value, (int)shotUpDown.Value).Item1, new Point(-startPictureBox.Width / 2, -startPictureBox.Height / 2));
                endPictureBox.Location = LocationOffsetPoint(GetShotLocation((int)rallyUpDown.Value, (int)shotUpDown.Value).Item2, new Point(-startPictureBox.Width / 2, -startPictureBox.Height / 2));

                overallCommonPlayerFlowLayoutPanel.Controls[0].Text = "";
                overallCommonOpponentFlowLayoutPanel.Controls[0].Text = "";

                List<string> shotTypePlayerList = new List<string>();
                List<string> shotTypeOpponentList = new List<string>();

                foreach (List<object> rally in rallies)
                {
                    DataFrame rallyAsDataframe = rally[0] as DataFrame;
                    foreach (DataFrameRow row in rallyAsDataframe.Rows)
                    {
                        if(row[6].ToString() == "Player")
                        {
                            shotTypePlayerList.Add(row[4].ToString());
                        }
                    }
                }

                foreach (List<object> rally in rallies)
                {
                    DataFrame rallyAsDataframe = rally[0] as DataFrame;
                    foreach (DataFrameRow row in rallyAsDataframe.Rows)
                    {
                        if (row[6].ToString() == "Opponent")
                        {
                            shotTypeOpponentList.Add(row[4].ToString());
                        }
                    }
                }

                string overallPlayerShotsMessage = "";
                foreach (List<string> shot in SortShots(shotTypePlayerList))
                {
                    overallPlayerShotsMessage += shot[0] + ": " + shot[1] + "\n";
                }

                string overallOpponentShotsMessage = "";
                foreach (List<string> shot in SortShots(shotTypeOpponentList))
                {
                    overallOpponentShotsMessage += shot[0] + ": " + shot[1] + "\n";
                }

                overallCommonPlayerFlowLayoutPanel.Controls[0].Text = overallPlayerShotsMessage;
                overallCommonOpponentFlowLayoutPanel.Controls[0].Text = overallOpponentShotsMessage;

                SetStatistics(playerShotPanel, playerSituationPanel, opponentShotPanel, opponentSituationPanel);

                SetFinalShots(finalPlayerWinningFlowLayoutPanel, finalPlayerLosingFlowLayoutPanel, finalOpponentWinningFlowLayoutPanel, finalOpponentLosingFlowLayoutPanel);
            }
        }

        private void getScoreButton_Click(object sender, EventArgs e)
        {
            scoreLabel.Text = GetScore(rallies, rallies.Count).Item1 + " : " + GetScore(rallies, rallies.Count).Item2;
        }

        private void shotUpDown_ValueChanged(object sender, EventArgs e)
        {
            rallyUpDown.Maximum = rallies.Count;
            DataFrame shotCountFrame = rallies[(int)rallyUpDown.Value - 1][0] as DataFrame;
            long shotCount = shotCountFrame.Rows.Count;
            shotUpDown.Maximum = shotCount;
            startPictureBox.Location = LocationOffsetPoint(GetShotLocation((int)rallyUpDown.Value, (int)shotUpDown.Value).Item1, new Point(-startPictureBox.Width / 2, -startPictureBox.Height / 2));
            endPictureBox.Location = LocationOffsetPoint(GetShotLocation((int)rallyUpDown.Value, (int)shotUpDown.Value).Item2, new Point(-startPictureBox.Width / 2, -startPictureBox.Height / 2));
            shotTypeLabel.Text = GetShot((int)rallyUpDown.Value, (int)shotUpDown.Value)[6] + "\n" + GetShot((int)rallyUpDown.Value, (int)shotUpDown.Value)[5] + "\n" + GetShotType((int)rallyUpDown.Value, (int)shotUpDown.Value);

            scoreLabel.Text = GetScore(rallies, (int)rallyUpDown.Value).Item1 + " : " + GetScore(rallies, (int)rallyUpDown.Value).Item2;

            courtPictureBox.Invalidate();
        }

        private void rallyUpDown_ValueChanged(object sender, EventArgs e)
        {
            rallyUpDown.Maximum = rallies.Count;
            DataFrame shotCountFrame = rallies[(int)rallyUpDown.Value - 1][0] as DataFrame;
            long shotCount = shotCountFrame.Rows.Count;
            shotUpDown.Maximum = shotCount;
            startPictureBox.Location = LocationOffsetPoint(GetShotLocation((int)rallyUpDown.Value, (int)shotUpDown.Value).Item1, new Point(-startPictureBox.Width / 2, -startPictureBox.Height / 2));
            endPictureBox.Location = LocationOffsetPoint(GetShotLocation((int)rallyUpDown.Value, (int)shotUpDown.Value).Item2, new Point(-startPictureBox.Width / 2, -startPictureBox.Height / 2));
            shotTypeLabel.Text = GetShot((int)rallyUpDown.Value, (int)shotUpDown.Value)[6] + "\n" + GetShot((int)rallyUpDown.Value, (int)shotUpDown.Value)[5] + "\n" + GetShotType((int)rallyUpDown.Value, (int)shotUpDown.Value);

            scoreLabel.Text = GetScore(rallies, (int)rallyUpDown.Value).Item1 + " : " + GetScore(rallies, (int)rallyUpDown.Value).Item2;

            courtPictureBox.Invalidate();
        }

        private void dataInputWindowButton_Click(object sender, EventArgs e)
        {
            if (frm1 == null)
            {
                Debug.WriteLine("Form 1 is null, created a new one");
                frm1 = new Form1();
                frm1.FormClosed += new FormClosedEventHandler(frm1_FormClosed);

                frm1.Show(this);
            }
            else
            {
                Debug.WriteLine("Focused on Form 1");
                frm1.Focus();
                frm1.BringToFront();
            }
        }

        void frm1_FormClosed(object sender, EventArgs e)
        {
            Debug.WriteLine("Form 1 closed");
            frm1 = null;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm1.SaveGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Do you want to save the game?",
                                     "Save File",
                                     MessageBoxButtons.YesNoCancel);

            if (confirmResult == DialogResult.Yes)
            {
                frm1.SaveGame();

                for (int i = Application.OpenForms.Count - 1; i != -1; i = Application.OpenForms.Count - 1)
                {
                    Application.OpenForms[i].Close();
                }
            }
            else if (confirmResult == DialogResult.No)
            {
                for (int i = Application.OpenForms.Count - 1; i != -1; i = Application.OpenForms.Count - 1)
                {
                    Application.OpenForms[i].Close();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm1.OpenFile();
        }

        public void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Do you want to save the game?",
                                     "Save File",
                                     MessageBoxButtons.YesNoCancel);

            if (confirmResult == DialogResult.Yes)
            {
                frm1.SaveGame();

                Process process = null;
                try
                {
                    process = Process.GetCurrentProcess();
                    process.WaitForExit(1000);
                }
                catch
                {
                }
                for (int i = Application.OpenForms.Count - 1; i != -1; i = Application.OpenForms.Count - 1)
                {
                    Application.OpenForms[i].Close();
                }
                Process.Start("BadmintonApp");
            }
            else if (confirmResult == DialogResult.No)
            {
                Process process = null;
                try
                {
                    process = Process.GetCurrentProcess();
                    process.WaitForExit(1000);
                }
                catch
                {
                }
                for (int i = Application.OpenForms.Count - 1; i != -1; i = Application.OpenForms.Count - 1)
                {
                    Application.OpenForms[i].Close();
                }
                Process.Start("BadmintonApp");
            }
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            SetStatistics(playerShotPanel, playerSituationPanel, opponentShotPanel, opponentSituationPanel);
            HandleCourtStatisticsShotInOut();
            HandleCourtStatisticsRallyOutcome();
        }

        private void CourtMouseClick(object sender, MouseEventArgs e)
        {
            pointPictureBox.Location = LocationOffsetPoint(e.Location, new Point(-pointPictureBox.Width / 2, -pointPictureBox.Height / 2));

            HandleCourtStatisticsShot();
            HandleCourtStatisticsShotInOut();
            HandleCourtStatisticsRallyOutcome();

            courtPictureBox1.Invalidate();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogForm dialogForm = new DialogForm();
            dialogForm.Show();
        }

        private void neutralButton_Click(object sender, EventArgs e)
        {
            processSituationButtonClick(neutralButton);

            HandleCourtStatisticsShot();
            HandleCourtStatisticsShotInOut();
            HandleCourtStatisticsRallyOutcome();

            courtPictureBox1.Invalidate();
        }

        private void attackingButton_Click(object sender, EventArgs e)
        {
            processSituationButtonClick(attackingButton);

            HandleCourtStatisticsShot();
            HandleCourtStatisticsShotInOut();
            HandleCourtStatisticsRallyOutcome();

            courtPictureBox1.Invalidate();
        }

        private void defendingButton_Click(object sender, EventArgs e)
        {
            processSituationButtonClick(defendingButton);

            HandleCourtStatisticsShot();
            HandleCourtStatisticsShotInOut();
            HandleCourtStatisticsRallyOutcome();

            courtPictureBox1.Invalidate();
        }

        private void courtPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (var pen = new Pen(Color.DarkSlateGray, 5))
            {
                g.DrawLine(pen, LocationOffsetPoint(startPictureBox.Location, new Point(startPictureBox.Width / 2, startPictureBox.Height / 2)), LocationOffsetPoint(endPictureBox.Location, new Point(endPictureBox.Width / 2, endPictureBox.Height / 2)));
            }
        }

        private void courtPictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (endBigPictureBox.Location.Y >= -12)
            {
                using (var pen = new Pen(Color.DarkSlateGray, 6))
                {
                    g.DrawLine(pen, LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), LocationOffsetPoint(endBigPictureBox.Location, new Point(endBigPictureBox.Width / 2, endBigPictureBox.Height / 2)));
                }
            }

            if (endMediumPictureBox.Location.Y >= -12)
            {
                using (var pen = new Pen(Color.DarkSlateGray, 3))
                {
                    g.DrawLine(pen, LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), LocationOffsetPoint(endMediumPictureBox.Location, new Point(endMediumPictureBox.Width / 2, endMediumPictureBox.Height / 2)));
                }
            }

            if (endSmallPictureBox.Location.Y >= -12)
            {
                using (var pen = new Pen(Color.DarkSlateGray, 1))
                {
                    g.DrawLine(pen, LocationOffsetPoint(pointPictureBox.Location, new Point(pointPictureBox.Width / 2, pointPictureBox.Height / 2)), LocationOffsetPoint(endSmallPictureBox.Location, new Point(endSmallPictureBox.Width / 2, endSmallPictureBox.Height / 2)));
                }
            }
        }
    }
}
