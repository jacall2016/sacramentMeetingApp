using Microsoft.EntityFrameworkCore;
using sacramentMeetingApp.Data;

namespace sacramentMeetingApp.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new sacramentMeetingAppContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<sacramentMeetingAppContext>>()))
        {
            if (context == null || context.Hymn == null || context.Member == null || context.Unit == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any members.
            if (context.Member.Any())
            {
                return;   // DB has been seeded
            }

            context.Member.AddRange(
                new Member { Name = "John Doe", Position = "Bishop", Gender = GenderType.Male },
                new Member { Name = "Kevin William", Position = "First Counselor", Gender = GenderType.Male },
                new Member { Name = "Duran Smith", Position = "Second Counselor", Gender = GenderType.Male },
                new Member { Name = "Bob Johnson", Position = "Clerk", Gender = GenderType.Male },
                new Member { Name = "Charlie Brown", Position = "Member", Gender = GenderType.Male },
                new Member { Name = "Diana Prince", Position = "Member", Gender = GenderType.Female },
                new Member { Name = "Edward Cullen", Position = "Member", Gender = GenderType.Male },
                new Member { Name = "Fiona Shrek", Position = "Member", Gender = GenderType.Female },
                new Member { Name = "George Weasley", Position = "Member", Gender = GenderType.Male },
                new Member { Name = "Hermione Granger", Position = "Member", Gender = GenderType.Female },
                new Member { Name = "Igor Karkaroff", Position = "Member", Gender = GenderType.Male },
                new Member { Name = "Jack Sparrow", Position = "Member", Gender = GenderType.Male },
                new Member { Name = "Kitty Pryde", Position = "Member", Gender = GenderType.Female },
                new Member { Name = "Luke Skywalker", Position = "Member", Gender = GenderType.Male },
                new Member { Name = "Minnie Mouse", Position = "Member", Gender = GenderType.Female }
            );
            
            context.SaveChanges();

            // Look for any units.
            if (context.Unit.Any())
            {
                return;   // DB has been seeded
            }

            context.Unit.AddRange(
                new Unit { UnitName = "Sunset Ward", UnitType = UnitType.Ward },
                new Unit { UnitName = "Riverside Branch", UnitType = UnitType.Branch },
                new Unit { UnitName = "Mountain View Unit", UnitType = UnitType.Unit },
                new Unit { UnitName = "Ocean Side Ward", UnitType = UnitType.Ward },
                new Unit { UnitName = "Green Valley Branch", UnitType = UnitType.Branch }
            );

            context.SaveChanges();

            // Look for any hymns.
            if (context.Hymn.Any())
            {
                return;   // DB has been seeded
            }

            context.Hymn.AddRange(
                new Hymn { Title = "#1 - The Morning Breaks" },
                new Hymn { Title = "#2 - The Spirit of God" },
                new Hymn { Title = "#3 - Now Let Us Rejoice" },
                new Hymn { Title = "#4 - Truth Eternal" },
                new Hymn { Title = "#5 - High on the Mountain Top" },
                new Hymn { Title = "#6 - Redeemer of Israel" },
                new Hymn { Title = "#7 - Israel, Israel, God Is Calling" },
                new Hymn { Title = "#8 - Awake and Arise" },
                new Hymn { Title = "#9 - Come, Rejoice" },
                new Hymn { Title = "#10 - Come, Sing to the Lord" },
                new Hymn { Title = "#11 - What Was Witnessed in the Heavens?" },
                new Hymn { Title = "#12 - 'Twas Witnessed in the Morning Sky" },
                new Hymn { Title = "#13 - An Angel from on High" },
                new Hymn { Title = "#14 - Sweet Is the Peace the Gospel Brings" },
                new Hymn { Title = "#15 - I Saw a Mighty Angel Fly" },
                new Hymn { Title = "#16 - What Glorious Scenes Mine Eyes Behold" },
                new Hymn { Title = "#17 - Awake, Ye Saints of God, Awake!" },
                new Hymn { Title = "#18 - The Voice of God Again Is Heard" },
                new Hymn { Title = "#19 - We Thank Thee, O God, for a Prophet" },
                new Hymn { Title = "#20 - God of Power, God of Right" },
                new Hymn { Title = "#21 - Come, Listen to a Prophet's Voice" },
                new Hymn { Title = "#22 - We Listen to a Prophet's Voice" },
                new Hymn { Title = "#23 - We Ever Pray for Thee" },
                new Hymn { Title = "#24 - God Bless Our Prophet Dear" },
                new Hymn { Title = "#25 - Now We'll Sing with One Accord" },
                new Hymn { Title = "#26 - Joseph Smith's First Prayer" },
                new Hymn { Title = "#27 - Praise to the Man" },
                new Hymn { Title = "#28 - Saints, Behold How Great Jehovah" },
                new Hymn { Title = "#29 - A Poor Wayfaring Man of Grief" },
                new Hymn { Title = "#30 - Come, Come, Ye Saints" },
                new Hymn { Title = "#31 - O God, Our Help in Ages Past" },
                new Hymn { Title = "#32 - The Happy Day at Last Has Come" },
                new Hymn { Title = "#33 - Our Mountain Home So Dear" },
                new Hymn { Title = "#34 - O Ye Mountains High" },
                new Hymn { Title = "#35 - For the Strength of the Hills" },
                new Hymn { Title = "#36 - They, the Builders of the Nation" },
                new Hymn { Title = "#37 - The Wintry Day, Descending to Its Close" },
                new Hymn { Title = "#38 - Come, All Ye Saints of Zion" },
                new Hymn { Title = "#39 - O Saints of Zion" },
                new Hymn { Title = "#40 - Arise, O Glorious Zion" },
                new Hymn { Title = "#41 - Let Zion in Her Beauty Rise" },
                new Hymn { Title = "#42 - Hail to the Brightness of Zion's Glad Morning!" },
                new Hymn { Title = "#43 - Zion Stands with Hills Surrounded" },
                new Hymn { Title = "#44 - Beautiful Zion, Built Above" },
                new Hymn { Title = "#45 - Lead Me into Life Eternal" },
                new Hymn { Title = "#46 - Glorious Things of Thee Are Spoken" },
                new Hymn { Title = "#47 - We Will Sing of Zion" },
                new Hymn { Title = "#48 - Glorious Things Are Sung of Zion" },
                new Hymn { Title = "#49 - Adam-ondi-Ahman" },
                new Hymn { Title = "#50 - Come, Thou Glorious Day of Promise" },
                new Hymn { Title = "#51 - Sons of Michael, He Approaches" },
                new Hymn { Title = "#52 - The Day Dawn Is Breaking" },
                new Hymn { Title = "#53 - Let Earth's Inhabitants Rejoice" },
                new Hymn { Title = "#54 - Behold, the Mountain of the Lord" },
                new Hymn { Title = "#55 - Lo, the Mighty God Appearing!" },
                new Hymn { Title = "#56 - Softly Beams the Sacred Dawning" },
                new Hymn { Title = "#57 - We're Not Ashamed to Own Our Lord" },
                new Hymn { Title = "#58 - Come, Ye Children of the Lord" },
                new Hymn { Title = "#59 - Come, O Thou King of Kings" },
                new Hymn { Title = "#60 - Battle Hymn of the Republic" },
                new Hymn { Title = "#61 - Raise Your Voices to the Lord" },
                new Hymn { Title = "#62 - All Creatures of Our God and King" },
                new Hymn { Title = "#63 - Great King of Heaven" },
                new Hymn { Title = "#64 - On This Day of Joy and Gladness" },
                new Hymn { Title = "#65 - Come, All Ye Saints Who Dwell on Earth" },
                new Hymn { Title = "#66 - Rejoice, the Lord Is King!" },
                new Hymn { Title = "#67 - Glory to God on High" },
                new Hymn { Title = "#68 - A Mighty Fortress Is Our God" },
                new Hymn { Title = "#69 - All Glory, Laud, and Honor" },
                new Hymn { Title = "#70 - Sing Praise to Him" },
                new Hymn { Title = "#71 - With Songs of Praise" },
                new Hymn { Title = "#72 - Praise to the Lord, the Almighty" },
                new Hymn { Title = "#73 - Praise the Lord with Heart and Voice" },
                new Hymn { Title = "#74 - Praise Ye the Lord" },
                new Hymn { Title = "#75 - In Hymns of Praise" },
                new Hymn { Title = "#76 - God of Our Fathers, We Come unto Thee" },
                new Hymn { Title = "#77 - Great Is the Lord" },
                new Hymn { Title = "#78 - God of Our Fathers, Whose Almighty Hand" },
                new Hymn { Title = "#79 - With All the Power of Heart and Tongue" },
                new Hymn { Title = "#80 - God of Our Fathers, Known of Old" },
                new Hymn { Title = "#81 - Press Forward, Saints" },
                new Hymn { Title = "#82 - For All the Saints" },
                new Hymn { Title = "#83 - Guide Us, O Thou Great Jehovah" },
                new Hymn { Title = "#84 - Faith of Our Fathers" },
                new Hymn { Title = "#85 - How Firm a Foundation" },
                new Hymn { Title = "#86 - How Great Thou Art" },
                new Hymn { Title = "#87 - God Is Love" },
                new Hymn { Title = "#88 - Great God, Attend While Zion Sings" },
                new Hymn { Title = "#89 - The Lord Is My Light" },
                new Hymn { Title = "#90 - From All That Dwell below the Skies" },
                new Hymn { Title = "#91 - Father, Thy Children to Thee Now Raise" },
                new Hymn { Title = "#92 - For the Beauty of the Earth" },
                new Hymn { Title = "#93 - Prayer of Thanksgiving" },
                new Hymn { Title = "#94 - Come, Ye Thankful People" },
                new Hymn { Title = "#95 - Now Thank We All Our God" },
                new Hymn { Title = "#96 - Dearest Children, God Is Near You" },
                new Hymn { Title = "#97 - Lead, Kindly Light" },
                new Hymn { Title = "#98 - I Need Thee Every Hour" },
                new Hymn { Title = "#99 - Nearer, Dear Savior, to Thee" },
                new Hymn { Title = "#100 - Nearer, My God, to Thee" },
                new Hymn { Title = "#101 - Guide Me to Thee" },
                new Hymn { Title = "#102 - Jesus, Lover of My Soul" },
                new Hymn { Title = "#103 - Precious Savior, Dear Redeemer" },
                new Hymn { Title = "#104 - Jesus, Savior, Pilot Me" },
                new Hymn { Title = "#105 - Master, the Tempest Is Raging" },
                new Hymn { Title = "#106 - God Speed the Right" },
                new Hymn { Title = "#107 - Lord, Accept Our True Devotion" },
                new Hymn { Title = "#108 - The Lord Is My Shepherd" },
                new Hymn { Title = "#109 - The Lord My Pasture Will Prepare" },
                new Hymn { Title = "#110 - Cast Thy Burden upon the Lord" },
                new Hymn { Title = "#111 - Rock of Ages" },
                new Hymn { Title = "#112 - Savior, Redeemer of My Soul" },
                new Hymn { Title = "#113 - Our Savior's Love" },
                new Hymn { Title = "#114 - Come unto Him" },
                new Hymn { Title = "#115 - Come, Ye Disconsolate" },
                new Hymn { Title = "#116 - Come, Follow Me" },
                new Hymn { Title = "#117 - Come unto Jesus" },
                new Hymn { Title = "#118 - Ye Simple Souls Who Stray" },
                new Hymn { Title = "#119 - Come, We That Love the Lord" },
                new Hymn { Title = "#120 - Lean on My Ample Arm" },
                new Hymn { Title = "#121 - I'm a Pilgrim, I'm a Stranger" },
                new Hymn { Title = "#122 - Though Deepening Trials" },
                new Hymn { Title = "#123 - Oh, May My Soul Commune with Thee" },
                new Hymn { Title = "#124 - Be Still, My Soul" },
                new Hymn { Title = "#125 - How Gentle God's Commands" },
                new Hymn { Title = "#126 - How Long, O Lord Most Holy and True" }
            );

            context.SaveChanges();
        }
    }
}