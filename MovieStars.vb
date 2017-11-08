'=========================================================================
'Project:           Lab 1
'Title:             Movie Stars
'File Name:         MovieStars.vb
'Date Finished:     3/5/2016
'
'Name:              Mannat Sharma and Tamanna Sharma
'Class:             CS 115 Section B Winter 2016
'
'Description:      This program will allow the user to see articles about 
'                  ten movie stars.The user could see the article 
'                  and some information about stars by clicking 
'                  on their favorite stars.The user could increase or decrease the 
'                  size of article.The user could bold , underline, italic
'                  the information.The user could change the font color in blue.
'                  The user could chage the background color.The user could 
'                  fullscreen the article, as well. The user could see
'                  the credit of the articles. The user could compose the 
'                  article, as well.There is a button to exit the program.
'=========================================================================

Option Explicit On
Option Strict On

Public Class frmMovieStars

    Dim cstrPath As String = "..\Data\"
    Dim strTemp As String
    Dim sngFontSize As Single = 14.25
    Dim showa As Boolean = False

    Private Sub frmMovieStars_Load(sender As Object, e As EventArgs) Handles Me.Load

        '---------------------------------------------------------------------------
        'Description:  It will set the start up environment. It will keep rtbCompose blank.
        '              First, it will show a message to the user when the program 
        '              is runned. It will arrange the order of celebrities when the
        '              program starts. It will also make the scroller move.
        '---------------------------------------------------------------------------

        If MsgBox("HI," & Chr(13) & Chr(13) & " GET INFORMATION ABOUT 10 MOVIE STARS", MsgBoxStyle.OkCancel, "Welcome") = Windows.Forms.DialogResult.Cancel Then
            Me.Close()

        End If

        rtbCompose.Clear()

        Const shtSPACE As Short = 3
        Const shtOrder As Short = 5

        radAngelinaJolie.Top = shtSPACE
        radAngelinaJolie.Left = shtSPACE
        radAnnaKendrick.Top = radAngelinaJolie.Top + radAngelinaJolie.Height + shtSPACE
        radAnnaKendrick.Left = radAngelinaJolie.Left
        radChrisPine.Top = radAnnaKendrick.Top + radAnnaKendrick.Height + shtSPACE
        radChrisPine.Left = radAnnaKendrick.Left
        radEddieRadmyen.Top = radChrisPine.Top + radChrisPine.Height + shtSPACE
        radEddieRadmyen.Left = radChrisPine.Left
        radJakeGyllenhaal.Top = radEddieRadmyen.Top + radEddieRadmyen.Height + shtSPACE
        radJakeGyllenhaal.Left = radEddieRadmyen.Left
        radKevinHart.Top = radJakeGyllenhaal.Top + radJakeGyllenhaal.Height + shtSPACE
        radKevinHart.Left = radJakeGyllenhaal.Left
        radNataliePortman.Top = radKevinHart.Top + radKevinHart.Height + shtSPACE
        radNataliePortman.Left = radKevinHart.Left
        radNicoleKidman.Top = radNataliePortman.Top + radNataliePortman.Height + shtSPACE
        radNicoleKidman.Left = radNataliePortman.Left
        radTomHanks.Top = radNicoleKidman.Top + radNicoleKidman.Height + shtSPACE
        radTomHanks.Left = radNicoleKidman.Left
        radWillSmith.Top = radTomHanks.Top + radTomHanks.Height + shtSPACE
        radWillSmith.Left = radTomHanks.Left


        pnlCelebs.Width = radAngelinaJolie.Width
        pnlCelebs.Height = 10 * radAngelinaJolie.Height + 20 * shtSPACE

        pnlCelebs.Left = 0
        pnlCelebs.Top = shtOrder

        vsbChoices.Left = pnlCelebs.Left + pnlCelebs.Width + shtSPACE
        vsbChoices.Top = pnlCelebs.Top

        pnlChoices.Width = vsbChoices.Width + vsbChoices.Left
        pnlChoices.Height = 2 * radAngelinaJolie.Height + shtSPACE * 10 + shtOrder
        vsbChoices.Height = pnlChoices.Height + shtOrder
        pnlChoices.Top = 37

        vsbChoices.Height = pnlChoices.Height - shtOrder
        vsbChoices.LargeChange = (radAngelinaJolie.Height + shtSPACE) * 2
        vsbChoices.Maximum = pnlCelebs.Height
        vsbChoices.SmallChange = CInt(vsbChoices.LargeChange / 5)

    End Sub

    Private Sub btnGoodBye_Click(sender As Object, e As EventArgs) Handles btnGoodBye.Click

        '---------------------------------------------------------------------------------
        'Description:        This will close the program with a message.
        '---------------------------------------------------------------------------------
        If MsgBox("Are you sure you want to quit?", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Close application") = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnFullScreen_Click(sender As Object, _
                                    e As EventArgs) Handles btnFullScreen.Click

        '---------------------------------------------------------------------------------
        'Description:        Through this user could switch between full-screen and
        '                    shrink-screen.
        '---------------------------------------------------------------------------------
       
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            btnFullScreen.Text = "Shrink-Screen"
        Else
            Me.WindowState = FormWindowState.Normal
            btnFullScreen.Text = "Full-Screen"
        End If


    End Sub

    Private Sub chkBold_Click(sender As Object, e As EventArgs) Handles chkBold.Click

        '---------------------------------------------------------------------------------
        'Description:      The user could bold the information and could unbold 
        '                  it as well.  
        '---------------------------------------------------------------------------------

        If (chkItalic.Checked And chkBold.Checked And chkUnderline.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Bold Or FontStyle.Underline)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic Or _
                                       FontStyle.Bold Or FontStyle.Underline)

        ElseIf (chkBold.Checked And chkItalic.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Bold _
                                       Or FontStyle.Italic)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Bold _
                                       Or FontStyle.Italic)

        ElseIf (chkBold.Checked And chkUnderline.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Bold _
                                       Or FontStyle.Underline)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Bold _
                                       Or FontStyle.Underline)

        ElseIf (chkUnderline.Checked And chkItalic.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Underline)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Underline)

        ElseIf (chkBold.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Bold)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Bold)

        ElseIf (chkUnderline.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Underline)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Underline)

        ElseIf (chkItalic.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic)

        Else
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Regular)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Regular)

        End If
    End Sub

    Private Sub chkBlue_Click(sender As Object, e As EventArgs) Handles chkBlue.Click

        '---------------------------------------------------------------------------------
        'Description:   The user could change the text color to blue and back to black     
        '---------------------------------------------------------------------------------

        If (chkBlue.Checked) Then
            rtbCompose.ForeColor = Color.Blue
            rtbArticle.ForeColor = Color.Blue
        Else
            rtbCompose.ForeColor = Color.Black
            rtbArticle.ForeColor = Color.Black
        End If

    End Sub


    Private Sub chkItalic_Click(sender As Object, e As EventArgs) Handles chkItalic.Click

        '---------------------------------------------------------------------------------
        'Description:   The user could italic the information and could unitalic
        '               it as well.       
        '---------------------------------------------------------------------------------

        If (chkItalic.Checked And chkBold.Checked And chkUnderline.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Bold Or FontStyle.Underline)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Bold Or FontStyle.Underline)

        ElseIf (chkItalic.Checked And chkBold.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Bold)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Bold)

        ElseIf (chkItalic.Checked And chkUnderline.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Underline)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Underline)

        ElseIf (chkUnderline.Checked And chkBold.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Underline _
                                       Or FontStyle.Bold)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Underline _
                                       Or FontStyle.Bold)

        ElseIf (chkItalic.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic)

        ElseIf (chkBold.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Bold)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Bold)

        ElseIf (chkUnderline.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Underline)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Underline)

        Else
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Regular)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Regular)

        End If

    End Sub


    Private Sub chkUnderline_Click(sender As Object, e As EventArgs) Handles chkUnderline.Click

        '---------------------------------------------------------------------------------
        'Description:    The user could underline the information and could get it
        '                back to normal.      
        '---------------------------------------------------------------------------------

        If (chkItalic.Checked And chkBold.Checked And chkUnderline.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Bold Or FontStyle.Underline)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Bold Or FontStyle.Underline)

        ElseIf (chkUnderline.Checked And chkBold.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Underline _
                                       Or FontStyle.Bold)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Underline _
                                       Or FontStyle.Bold)

        ElseIf (chkUnderline.Checked And chkItalic.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Underline)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Underline)

        ElseIf (chkItalic.Checked And chkBold.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Bold)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic _
                                       Or FontStyle.Bold)

        ElseIf (chkUnderline.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Underline)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Underline)

        ElseIf (chkItalic.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Italic)

        ElseIf (chkBold.Checked) Then
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Bold)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Bold)

        Else
            rtbCompose.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Regular)
            rtbArticle.Font = New Font("Times new roman", rtbCompose.Font.Size, FontStyle.Regular)

        End If

    End Sub

    Private Sub chkBackColor_Click(sender As Object, e As EventArgs) Handles chkBackColor.Click

        '---------------------------------------------------------------------------------
        'Description:        The user could switch the back color between light blue
        '                    and white
        '---------------------------------------------------------------------------------

        If (chkBackColor.Checked) Then
            rtbCompose.BackColor = Color.LightBlue
            rtbArticle.BackColor = Color.LightBlue
        Else
            rtbCompose.BackColor = Color.White
            rtbArticle.BackColor = Color.White
        End If
    End Sub

    Private Sub btnShowArticle_Click(sender As Object, _
                                     e As EventArgs) Handles btnShowArticle.Click

        '---------------------------------------------------------------------------------
        'Description:  It will show, how the article finally looks with all the editing.  
        '----------------------------------------------------------------------------------

        If showa = False Then

            btnShowArticle.Text = "Compose"
            rtbCompose.Visible = False
            pnlCelebs.Visible = False
            pnlChoices.Visible = False
            txtArticleTitle.Visible = False
            txtDate.Visible = False
            txtReporter.Visible = False
            lblArticle.Visible = False
            lblCredit.Visible = False
            lblDate.Visible = False
            lblReporter.Visible = False
            lblStarBio.Visible = False
            rtbArticle.Visible = True
            pnlArticle.Visible = True

            rtbArticle.Text = txtArticleTitle.Text & Chr(13) & Chr(13) & _
            txtReporter.Text & Chr(13) & Chr(13) & txtDate.Text & Chr(13) & _
            Chr(13) & rtbCompose.Text

            rtbArticle.Top = 18
            rtbArticle.Left = 0
            rtbArticle.Height = 410
            rtbArticle.Width = pnlStyle.Width
            pnlArticle.Top = 15
            pnlArticle.Left = 0
            pnlArticle.Height = 444
            pnlArticle.Width = pnlStyle.Width

            showa = True
        Else
            btnShowArticle.Text = "Show Article"
            rtbCompose.Visible = True
            pnlCelebs.Visible = True
            pnlChoices.Visible = True
            txtArticleTitle.Visible = True
            txtDate.Visible = True
            txtReporter.Visible = True
            lblArticle.Visible = True
            lblCredit.Visible = True
            lblDate.Visible = True
            lblReporter.Visible = True
            lblStarBio.Visible = True
            rtbArticle.Visible = False
            pnlArticle.Visible = False

            showa = False

        End If

    End Sub

    Private Sub btnFontBigger_Click(sender As Object, e As EventArgs) Handles btnFontBigger.Click

        '---------------------------------------------------------------------------------
        'Description:        The user could increase the size of text on each click.
        '---------------------------------------------------------------------------------

        If sngFontSize < 26 Then
            sngFontSize += 1
            rtbCompose.Font = New Font("Times new roman", sngFontSize, rtbCompose.Font.Style)
            rtbArticle.Font = New Font("Times new roman", sngFontSize, rtbCompose.Font.Style)

        End If

    End Sub

    Private Sub btnFontSmall_Click(sender As Object, e As EventArgs) Handles btnFontSmall.Click

        '---------------------------------------------------------------------------------
        'Description:        The user could decrease the size of text on each click.
        '---------------------------------------------------------------------------------

        If sngFontSize > 7 Then
            sngFontSize -= 1
            rtbCompose.Font = New Font("Times new roman", sngFontSize, rtbCompose.Font.Style)
            rtbArticle.Font = New Font("Times new roman", sngFontSize, rtbCompose.Font.Style)

        End If

    End Sub

    Private Sub vsbChoices_Scroll(sender As Object, _
                                    e As ScrollEventArgs) Handles vsbChoices.Scroll

        '---------------------------------------------------------------------------------
        'Description:   It will scroll vertically, and user could see the movie stars
        '               radio buttons.
        '---------------------------------------------------------------------------------

        pnlCelebs.Top = vsbChoices.Value * -1

    End Sub

    Private Sub radAngelinaJolie_Click(sender As Object, e As EventArgs) Handles radAngelinaJolie.Click

        '---------------------------------------------------------------------------------
        'Description:        When the user will click on this radio button,
        '                    this will import the data about Angelina Jolie
        '                    and would show it in rtbCompose for editing.Also, 
        '                    it will show some basic information
        '                    about Angelina Jolie in lblStarBio,
        '                    the title of the article in txtArticleTitle,
        '                    the date when the article was publiched in  
        '                    txtDate and the name of the reporter in txtReporter
        '---------------------------------------------------------------------------------

        rtbCompose.Clear()
        strTemp = ""

        FileOpen(7, cstrPath & "Angelina Jolie.txt", OpenMode.Input)
        Do Until EOF(7) = True
            Input(7, strTemp)
            rtbCompose.Text &= strTemp
        Loop
        lblStarBio.Text = ""
        lblStarBio.Text = "Angelina Jolie is an American actress, and a filmmaker. " _
& "She is one of the Hollywood's highest-paid actress." _
& "She has won two Screen Actors Guild Awards, an Academy Award and three Golden Globe Awards."

        FileClose(7)
        txtArticleTitle.Clear()
        txtArticleTitle.Text = "Experts Back Angelina Jolie Pitt in Choices for Cancer Prevention"
        txtDate.Clear()
        txtDate.Text = "MARCH 24, 2015"
        txtReporter.Clear()
        txtReporter.Text = "PAM BELLUCK "

    End Sub

    Private Sub radAnnaKendrick_Click(sender As Object, e As EventArgs) Handles radAnnaKendrick.Click

        '---------------------------------------------------------------------------------
        'Description:        When the user will click on this radio button,
        '                    this will import the data about Anna Kendrick
        '                    and would show it in rtbCompose for editing.Also, 
        '                    it will show some basic information
        '                    about Anna Kendrick in lblStarBio,
        '                    the title of the article in txtArticleTitle,
        '                    the date when the article was publiched in  
        '                    txtDate and the name of the reporter in txtReporter
        '---------------------------------------------------------------------------------

        rtbCompose.Clear()
        strTemp = ""

        FileOpen(1, cstrPath & "Anna K.txt", OpenMode.Input)
        Do Until EOF(1) = True
            Input(1, strTemp)
            rtbCompose.Text &= strTemp
        Loop
        lblStarBio.Text = ""
        lblStarBio.Text = "Anna Kendrick is an American actress and a singer. " _
            & "She was a child actor in theater productions." _
            & " For the first time, she was in the 1998 Broadway musical High Society," _
            & "and she won a Tony Award nomination for Best Featured Actress in a Musical."
        txtArticleTitle.Clear()
        txtArticleTitle.Text = "Anna Kendrick: Up In The Air, And Down To Earth "
        txtDate.Clear()
        txtDate.Text = " January 28, 2015 "
        txtReporter.Clear()
        txtReporter.Text = "Patty Adams Martinez "
        FileClose(1)

    End Sub

    Private Sub radChrisPine_Click(sender As Object, e As EventArgs) Handles radChrisPine.Click

        '---------------------------------------------------------------------------------
        'Description:        When the user will click on this radio button,
        '                    this will import the data about Chris Pine
        '                    and would show it in rtbCompose for editing.Also, 
        '                    it will show some basic information
        '                    about Chris Pine in lblStarBio,
        '                    the title of the article in txtArticleTitle,
        '                    the date when the article was publiched in  
        '                    txtDate and the name of the reporter in txtReporter 
        '---------------------------------------------------------------------------------

        rtbCompose.Clear()
        strTemp = ""

        FileOpen(2, cstrPath & "Chris Pine.txt", OpenMode.Input)
        Do Until EOF(2) = True
            Input(2, strTemp)
            rtbCompose.Text &= strTemp
        Loop

        lblStarBio.Text = ""
        lblStarBio.Text = "Christopher Whitelaw, Chris is an American actor." _
            & "He is well recognised for roles like James T. Kirk in the reboot Star Trek (2009)," _
            & "Star Trek Into Darkness (2013) and Star Trek Beyond (2016)."
        FileClose(2)
        txtArticleTitle.Clear()
        txtArticleTitle.Text = "Chris Pine Is Having a Moment"
        txtDate.Clear()
        txtDate.Text = "MAY 14, 2013"
        txtReporter.Clear()
        txtReporter.Text = "Sanjiv Bhattacharya "

    End Sub

    Private Sub radEddieRadmyen_Click(sender As Object, e As EventArgs) Handles radEddieRadmyen.Click

        '---------------------------------------------------------------------------------
        'Description:        When the user will click on this radio button,
        '                    this will import the data about Eddie Radmyen
        '                    and would show it in rtbCompose for editing.Also, 
        '                    it will show some basic information
        '                    about Eddie Radmyen in lblStarBio,
        '                    the title of the article in txtArticleTitle,
        '                    the date when the article was publiched in  
        '                    txtDate and the name of the reporter in txtReporter 
        '---------------------------------------------------------------------------------

        rtbCompose.Clear()
        strTemp = ""

        FileOpen(8, cstrPath & "Eddie Redmayne.txt", OpenMode.Input)
        Do Until EOF(8) = True
            Input(8, strTemp)
            rtbCompose.Text &= strTemp
        Loop

        lblStarBio.Text = ""
        lblStarBio.Text = "Edward John David Redmayne," _
            & "Eddie Redmayne is an English actor, model and singer." _
            & "He started his career in theatre as well as in television." _
            & " and then he made his film debut in Like Minds(2006)."

        FileClose(8)
        txtArticleTitle.Clear()
        txtArticleTitle.Text = "How Eddie Redmayne Became Stephen Hawking in ‘The Theory of Everything’"
        txtDate.Clear()
        txtDate.Text = "OCTOBER 28, 2014"
        txtReporter.Clear()
        txtReporter.Text = "Ramin Setoodeh"

    End Sub

    Private Sub radJakeGyllenhaal_Click(sender As Object, e As EventArgs) Handles radJakeGyllenhaal.Click

        '---------------------------------------------------------------------------------
        'Description:        When the user will click on this radio button,
        '                    this will import the data about Jake Gyllenhaal
        '                    and would show it in rtbCompose for editing.Also, 
        '                    it will show some basic information
        '                    about Jake Gyllenhaal in lblStarBio,
        '                    the title of the article in txtArticleTitle,
        '                    the date when the article was publiched in  
        '                    txtDate and the name of the reporter in txtReporter
        '---------------------------------------------------------------------------------


        rtbCompose.Clear()
        strTemp = ""

        FileOpen(5, cstrPath & "Jake Gyllenhaal.txt", OpenMode.Input)
        Do Until EOF(5) = True
            Input(5, strTemp)
            rtbCompose.Text &= strTemp
        Loop

        lblStarBio.Text = ""
        lblStarBio.Text = "Jacob Benjamin, Jake Gyllenhaal  is an American actor." _
            & "He is from Gyllenhaal family." _
            & "He was a child actor with a debut in City Slickers (1991)"

        FileClose(5)
        txtArticleTitle.Clear()
        txtArticleTitle.Text = "Jake Gyllenhaal On His Evolution As An Actor " _
           & "and Why He Feels More 'Alive' Than Ever"
        txtDate.Clear()
        txtDate.Text = "February 28, 2014 "
        txtReporter.Clear()
        txtReporter.Text = "Nigel M Smith"

    End Sub

    Private Sub radKevinHart_CheckedChanged(sender As Object, _
                                e As EventArgs) Handles radKevinHart.CheckedChanged

        '---------------------------------------------------------------------------------
        'Description:        When the user will click on this radio button,
        '                    this will import the data about Kevin Hart
        '                    and would show it in rtbCompose for editing.Also, 
        '                    it will show some basic information
        '                    about Kevin Hart in lblStarBio,
        '                    the title of the article in txtArticleTitle,
        '                    the date when the article was publiched in  
        '                    txtDate and the name of the reporter in txtReporter
        '---------------------------------------------------------------------------------

        rtbCompose.Clear()
        strTemp = ""

        FileOpen(3, cstrPath & "Kevin Hart.txt", OpenMode.Input)
        Do Until EOF(3) = True
            Input(3, strTemp)
            rtbCompose.Text &= strTemp

        Loop
        lblStarBio.Text = ""
        lblStarBio.Text = "Kevin Darnell Hart is an American actor," _
            & "writer, comedian, and producer." _
            & "He is originally from Philadelphia, Pennsylvania," _
            & "He started his career by winning many comedy competitions in New England"

        FileClose(3)
        txtArticleTitle.Clear()
        txtArticleTitle.Text = "He’s the Most Successful Stand-Up Comic in America"
        txtDate.Clear()
        txtDate.Text = "APRIL 20 2012 "
        txtReporter.Clear()
        txtReporter.Text = "David Haglund"

    End Sub

    Private Sub radNataliePortman_Click(sender As Object, e As EventArgs) Handles radNataliePortman.Click

        '---------------------------------------------------------------------------------
        'Description:        When the user will click on this radio button,
        '                    this will import the data about Natalie Portman
        '                    and would show it in rtbCompose for editing.Also, 
        '                    it will show some basic information
        '                    about Natalie Posrtman in lblStarBio,
        '                    the title of the article in txtArticleTitle,
        '                    the date when the article was publiched in  
        '                    txtDate and the name of the reporter in txtReporter
        '---------------------------------------------------------------------------------

        rtbCompose.Clear()
        strTemp = ""

        FileOpen(6, cstrPath & "Natalie Portman.txt", OpenMode.Input)
        Do Until EOF(6) = True
            Input(6, strTemp)
            rtbCompose.Text &= strTemp
        Loop
        lblStarBio.Text = ""
        lblStarBio.Text = "Natalie Portman is an actress, film producer and film director." _
            & "She has American and Israeli citizenship." _
& " Her first movie was in 1994, Léon: The Professional"


        FileClose(6)
        txtArticleTitle.Clear()
        txtArticleTitle.Text = "Natalie Portman, Oscar Winner, Was Also a Precocious Scientist"
        txtDate.Clear()
        txtDate.Text = "FEB. 28, 2011"
        txtReporter.Clear()
        txtReporter.Text = "NATALIE ANGIER"

    End Sub

    Private Sub radNicoleKidman_Click(sender As Object, e As EventArgs) Handles radNicoleKidman.Click

        '---------------------------------------------------------------------------------
        'Description:        When the user will click on this radio button,
        '                    this will import the data about Nicole Kidman
        '                    and would show it in rtbCompose for editing.Also, 
        '                    it will show some basic information
        '                    about Nicole Kidman in lblStarBio,
        '                    the title of the article in txtArticleTitle,
        '                    the date when the article was publiched in  
        '                    txtDate and the name of the reporter in txtReporter
        '---------------------------------------------------------------------------------

        rtbCompose.Clear()
        strTemp = ""

        FileOpen(4, cstrPath & "Nicole Kidman.txt", OpenMode.Input)
        Do Until EOF(4) = True
            Input(4, strTemp)
            rtbCompose.Text &= strTemp
        Loop
        lblStarBio.Text = ""
        lblStarBio.Text = "Nicole Mary Kidman is an Australian actress and film producer." _
            & "She was in Dead Calm(1989) and a television series called Bangkok Hilton."

        FileClose(4)
        txtArticleTitle.Clear()
        txtArticleTitle.Text = "Nicole Kidman, in a Rare, " _
            & "Down-to-Earth Interview, on Her New Adventure"
        txtDate.Clear()
        txtDate.Text = "JULY 20, 2015 "
        txtReporter.Clear()
        txtReporter.Text = "JASON GAY"

    End Sub


    Private Sub radTomHanks_Click(sender As Object, e As EventArgs) Handles radTomHanks.Click

        '---------------------------------------------------------------------------------
        'Description:        When the user will click on this radio button,
        '                    this will import the data about Tom Hank
        '                    and would show it in rtbCompose for editing.Also, 
        '                    it will show some basic information
        '                    about Tom Hank in lblStarBio,
        '                    the title of the article in txtArticleTitle,
        '                    the date when the article was publiched in  
        '                    txtDate and the name of the reporter in txtReporter
        '---------------------------------------------------------------------------------

        rtbCompose.Clear()
        strTemp = ""

        FileOpen(10, cstrPath & "Tom Hanks.txt", OpenMode.Input)
        Do Until EOF(10) = True
            Input(10, strTemp)
            rtbCompose.Text &= strTemp
        Loop
        lblStarBio.Text = ""
        lblStarBio.Text = "Thomas Jeffrey Hanks is an American actor and filmmaker." _
            & "He had roles in Splash (1984), Big (1988)," _
            & "Philadelphia (1993), Forrest Gump (1994)," _
            & "Apollo 13 (1995), Saving Private Ryan, " _
            & "You've Got Mail (both 1998), The Green Mile (1999),etc."

        FileClose(10)
        txtArticleTitle.Clear()
        txtArticleTitle.Text = "I Owe It All to Community College"
        txtDate.Clear()
        txtDate.Text = "JAN. 14, 2015"
        txtReporter.Clear()
        txtReporter.Text = "TOM HANKS "

    End Sub

   
    Private Sub radWillSmith_Click(sender As Object, e As EventArgs) Handles radWillSmith.Click

        '---------------------------------------------------------------------------------
        'Description:        When the user will click on this radio button,
        '                    this will import the data about Will Smith
        '                    and would show it in rtbCompose for editing.Also, 
        '                    it will show some basic information
        '                    about Will Smith in lblStarBio,
        '                    the title of the article in txtArticleTitle,
        '                    the date when the article was publiched in  
        '                    txtDate and the name of the reporter in txtReporter
        '---------------------------------------------------------------------------------

        rtbCompose.Clear()
        strTemp = ""

        FileOpen(9, cstrPath & "Will Smith.txt", OpenMode.Input)
        Do Until EOF(9) = True
            Input(9, strTemp)
            rtbCompose.Text &= strTemp
        Loop
        lblStarBio.Text = ""
        lblStarBio.Text = "Willard Carroll ,Will Smith Jr. is an American" _
            & "actor, rapper, producer, and songwriter." _
            & "He was a part of television, film, and music." _
            & "He was called as the most powerful actor in Hollywood in 2007"

        FileClose(9)
        txtArticleTitle.Clear()
        txtArticleTitle.Text = "The Boycott Before: Rap and Resentment at the 1989 Grammys"
        txtDate.Clear()
        txtDate.Text = "FEB. 10, 2016"
        txtReporter.Clear()
        txtReporter.Text = "JOE COSCARELLI "

    End Sub

End Class
