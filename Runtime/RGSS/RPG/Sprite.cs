using IronRuby.Builtins;
using System.Collections.Generic;
namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Sprite : RGSS.Sprite
    {
        private static RubyArray _animations = new RubyArray();
        private static Hash _reference_count = new Hash(new Dictionary<object, object>());
        private int _whiten_duration = 0;
        private int _appear_duration = 0;
        private int _escape_duration = 0;
        private int _collapse_duration = 0;
        private int _damage_duration = 0;
        private int _animation_duration = 0;
        private bool _blink = false;
        private int _blink_count;
        private RGSS.Sprite _damage_sprite;
        private Animation _animation;
        private bool _animation_hit;
        private RubyArray _animation_sprites;
        private Animation _loop_animation;
        private RubyArray _loop_animation_sprites;
        private int _loop_animation_index;

        public Sprite() : this(null)
        {
        }

        public Sprite(Viewport viewport = null) : base(viewport)
        {
        }

        public override void dispose()
        {
            this.dispose_damage();
            this.dispose_animation();
            this.dispose_loop_animation();
            base.dispose();
        }

        public void whiten()
        {
            this.blend_type = 0;
            this.color.set(255, 255, 255, 128);
            this.opacity = 255;
            this._whiten_duration = 16;
            this._appear_duration = 0;
            this._escape_duration = 0;
            this._collapse_duration = 0;
        }

        public void appear()
        {
            this.blend_type = 0;
            this.color.set(0, 0, 0, 0);
            this.opacity = 0;
            this._appear_duration = 16;
            this._whiten_duration = 0;
            this._escape_duration = 0;
            this._collapse_duration = 0;
        }
        public void escape()
        {
            this.blend_type = 0;
            this.color.set(0, 0, 0, 0);
            this.opacity = 255;
            this._escape_duration = 32;
            this._whiten_duration = 0;
            this._appear_duration = 0;
            this._collapse_duration = 0;
        }
        public void collapse()
        {
            this.blend_type = 1;
            this.color.set(255, 64, 64, 255);
            this.opacity = 255;
            this._collapse_duration = 48;
            this._whiten_duration = 0;
            this._appear_duration = 0;
            this._escape_duration = 0;
        }

        public void damage(object value, bool critical)
        {
            this.dispose_damage();
            string damage_string = "";

            //TODO : 마이너스 데미지 생각 damage_string = value.abs.to_s
            damage_string = value.ToString();

            Bitmap bitmap = new Bitmap(160, 48);
            bitmap.font.name = "Arial Black";
            bitmap.font.size = 32;
            bitmap.font.color.set(0, 0, 0);
            bitmap.draw_text(-1, 12-1, 160, 36, damage_string, 1);
            bitmap.draw_text(+1, 12-1, 160, 36, damage_string, 1);
            bitmap.draw_text(-1, 12+1, 160, 36, damage_string, 1);
            bitmap.draw_text(+1, 12+1, 160, 36, damage_string, 1);

            //TODO : 마이너스면 bitmap.font.color.set(176, 255, 144)
            bitmap.font.color.set(255, 255, 255); //마이너스가 아닐 경우

            bitmap.draw_text(0, 12, 160, 36, damage_string, 1);
            if(critical)
            {
                bitmap.font.size = 20;
                bitmap.font.color.set(0, 0, 0);
                bitmap.draw_text(-1, -1, 160, 20, "CRITICAL", 1);
                bitmap.draw_text(+1, -1, 160, 20, "CRITICAL", 1);
                bitmap.draw_text(-1, +1, 160, 20, "CRITICAL", 1);
                bitmap.draw_text(+1, +1, 160, 20, "CRITICAL", 1);
                bitmap.font.color.set(255, 255, 255);
                bitmap.draw_text(0, 0, 160, 20, "CRITICAL", 1);
            }

            this._damage_sprite = new RGSS.Sprite(this.viewport);
            this._damage_sprite.bitmap = bitmap;
            this._damage_sprite.ox = 80;
            this._damage_sprite.oy = 20;
            this._damage_sprite.x = this.x;
            this._damage_sprite.y = this.y - this.oy / 2;
            this._damage_sprite.z = 3000;
            this._damage_duration = 40;
        }

        public void animation(Animation animation, bool hit)
        {
            this.dispose_animation();
            this._animation = animation;
            if(this._animation == null) return;
            this._animation_hit = hit;
            this._animation_duration = this._animation.frame_max;
            string animation_name = this._animation.animation_name;
            int animation_hue = this._animation.animation_hue;
            bitmap = Cache.animation(animation_name, animation_hue);

            int value = 0;
            if(Sprite._reference_count.ContainsKey(bitmap))
            {
                value = (int)Sprite._reference_count[bitmap];
            }
            Sprite._reference_count[bitmap] = value + 1;
            this._animation_sprites = new RubyArray();
            if(this._animation.position != 3 || !Sprite._animations.Contains(animation))
            {
                for(int i=0; i<16; i++)
                {
                    RGSS.Sprite sprite = new RGSS.Sprite(this.viewport);
                    sprite.bitmap = bitmap;
                    sprite.visible = false;
                    this._animation_sprites.Add(sprite);
                }

                if(!Sprite._animations.Contains(animation))
                {
                    Sprite._animations.Add(animation);
                }
            }

            this.update_animation();
        }

        public void loop_animation(Animation animation)
        {
            if(animation == this._loop_animation) return;
            this.dispose_loop_animation();
            this._loop_animation = animation;
            if(this._loop_animation == null) return;
            this._loop_animation_index = 0;

            string animation_name = this._loop_animation.animation_name;
            int animation_hue = this._loop_animation.animation_hue;
            bitmap = RPG.Cache.animation(animation_name, animation_hue);

            int value = 0;
            if(Sprite._reference_count.ContainsKey(bitmap))
            {
                value = (int)Sprite._reference_count[bitmap];
            }
            Sprite._reference_count[bitmap] = value + 1;

            this._loop_animation_sprites = new RubyArray();

            for(int i=0; i<16; i++)
            {
                RGSS.Sprite sprite = new RGSS.Sprite(this.viewport);
                sprite.bitmap = bitmap;
                sprite.visible = false;
                this._loop_animation_sprites.Add(sprite);
            }

            this.update_loop_animation();
        }

        public void dispose_damage()
        {
            if(this._damage_sprite != null)
            {
                this._damage_sprite.bitmap.dispose();
                this._damage_sprite.dispose();
                this._damage_sprite = null;
                this._damage_duration = 0;
            }
        }

        public void dispose_animation()
        {
            if(this._animation_sprites != null)
            {
                RGSS.Sprite sprite = (RGSS.Sprite)this._animation_sprites[0];

                if(sprite != null)
                {
                    int value = (int)Sprite._reference_count[sprite.bitmap];
                    Sprite._reference_count[sprite.bitmap] = value - 1;

                    if(((int)Sprite._reference_count[sprite.bitmap]) == 0)
                    {
                        sprite.bitmap.dispose();
                    }
                }

                foreach(object s in this._animation_sprites)
                {
                    ((RGSS.Sprite)s).dispose();
                }

                this._animation_sprites = null;
                this._animation = null;
            }
        }

        public void dispose_loop_animation()
        {
            if(this._loop_animation_sprites != null)
            {
                RGSS.Sprite sprite = (RGSS.Sprite)this._loop_animation_sprites[0];
                if(sprite != null)
                {
                    int value = (int)Sprite._reference_count[sprite.bitmap];
                    value -= 1;
                    Sprite._reference_count[sprite.bitmap] = value;

                    if(value == 0)
                    {
                        sprite.bitmap.dispose();
                    }
                }

                foreach(object s in this._loop_animation_sprites)
                {
                    ((RGSS.Sprite)s).dispose();
                }

                this._loop_animation_sprites = null;
                this._loop_animation = null;
            }
        }

        public void blink_on()
        {
            if(!this._blink)
            {
                this._blink = true;
                this._blink_count = 0;
            }
        }

        public void blink_off()
        {
            if(this._blink)
            {
                this._blink = false;
                this.color.set(0, 0, 0, 0);
            }
        }

        public bool IsBlink()
        {
            return this._blink;
        }

        public bool IsEffect()
        {
            return this._whiten_duration > 0 ||
                this._appear_duration > 0 ||
                this._escape_duration > 0 ||
                this._collapse_duration > 0 ||
                this._damage_duration > 0 ||
                this._animation_duration > 0;
        }

        public override void update()
        {
            base.update();

            if(this._whiten_duration > 0)
            {
                this._whiten_duration -= 1;
                this.color.alpha = 128 - (16 - this._whiten_duration) * 10;
            }

            if(this._appear_duration > 0)
            {
                this._appear_duration -= 1;
                this.opacity = (16 - this._appear_duration) * 16;
            }

            if(this._escape_duration > 0)
            {
                this._escape_duration -= 1;
                this.opacity = 256 - (32 - this._escape_duration) * 10;
            }

            if(this._collapse_duration > 0)
            {
                this._collapse_duration -= 1;
                this.opacity = 256 - (48 - this._collapse_duration) * 6;
            }

            if(this._damage_duration > 0)
            {
                this._damage_duration -= 1;
                switch(this._damage_duration)
                {
                    case 28:
                    case 29:
                    case 30:
                    case 31:
                    case 32:
                    case 33:
                        this._damage_sprite.y += 4;
                        break;
                    case 34:
                    case 35:
                        this._damage_sprite.y += 2;
                        break;
                    case 36:
                    case 37:
                        this._damage_sprite.y -= 2;
                        break;
                    case 38:
                    case 39:
                        this._damage_sprite.y -= 4;
                        break;
                    default:
                        break;
                }
                
                this._damage_sprite.opacity = 256 - (12 - this._damage_duration) * 32;

                if(this._damage_duration == 0)
                {
                    this.dispose_damage();
                }
            }

            if(this._animation != null && (Graphics.frame_count % 2 == 0))
            {
                this._animation_duration -= 1;
                this.update_animation();
            }

            if(this._loop_animation != null && (Graphics.frame_count % 2 == 0))
            {
                this.update_loop_animation();
                this._loop_animation_index += 1;
                this._loop_animation_index %= this._loop_animation.frame_max;
            }

            if(this._blink)
            {
                this._blink_count = (this._blink_count + 1) % 32;
                int alpha = 0;
                if(this._blink_count < 16)
                {
                    alpha = (16 - this._blink_count) * 6;
                }
                else
                {
                    alpha = (this._blink_count - 16) * 6;
                }

                this.color.set(255, 255, 255, alpha);
            }

            Sprite._animations.Clear();
        }

        public void update_animation()
        {
            if(this._animation_duration > 0)
            {
                int frame_index = this._animation.frame_max - this._animation_duration;
                Table cell_data = ((Animation.Frame)this._animation.frames[frame_index]).cell_data;
                int position = this._animation.position;
                
                animation_set_sprites(this._animation_sprites, cell_data, position);
                
                foreach(object timing_o in this._animation.timings)
                {
                    Animation.Timing timing = (Animation.Timing)timing_o;
                    
                    if(timing.frame == frame_index)
                    {
                        animation_process_timing(timing, this._animation_hit);
                    }
                }
            } else {
                this.dispose_animation();
            }
        }

        public void update_loop_animation()
        {
            int frame_index = this._loop_animation_index;
            Table cell_data = ((Animation.Frame)this._loop_animation.frames[frame_index]).cell_data;
            int position = this._loop_animation.position;

            animation_set_sprites(this._loop_animation_sprites, cell_data, position);

            foreach(object timing_o in this._loop_animation.timings)
            {
                Animation.Timing timing = (Animation.Timing)timing_o;

                if(timing.frame == frame_index)
                {
                    animation_process_timing(timing, true);
                }
            }
        }

        public void animation_set_sprites(RubyArray sprites, Table cell_data, int position)
        {
            for(int i=0; i<16; i++)
            {
                RGSS.Sprite sprite = (RGSS.Sprite)sprites[i];
                short pattern = cell_data[i, 0];

                if(sprite == null || pattern == null || pattern == -1)
                {
                    if(sprite != null) {
                        sprite.visible = false;
                    }

                    continue;
                }

                sprite.visible = true;
                sprite.src_rect.set(pattern % 5 * 192, pattern / 5 * 192, 192, 192);
                if(position == 3)
                {
                    if(this.viewport != null)
                    {
                        sprite.x = this.viewport.rect.width / 2;
                        sprite.y = this.viewport.rect.height - 160;
                    } else {
                        sprite.x = 320;
                        sprite.y = 240;
                    }
                } else {
                    sprite.x = this.x - this.ox + this.src_rect.width / 2;
                    sprite.y = this.y - this.oy + this.src_rect.height / 2;
                    if(position == 0) sprite.y -= this.src_rect.height / 4;
                    if(position == 2) sprite.y += this.src_rect.height / 4;
                }

                sprite.x += cell_data[i, 1];
                sprite.y += cell_data[i, 2];
                sprite.z = 2000;
                sprite.ox = 96;
                sprite.oy = 96;
                sprite.zoom_x = cell_data[i, 3] / 100.0;
                sprite.zoom_y = cell_data[i, 3] / 100.0;
                sprite.angle = cell_data[i, 4];
                sprite.mirror = (cell_data[i, 5] == 1);
                sprite.opacity = (int)(cell_data[i, 6] * this.opacity / 255.0);
                sprite.blend_type = cell_data[i, 7];
            }
        }

        public void animation_process_timing(Animation.Timing timing, bool hit)
        {
            if((timing.condition == 0) || (timing.condition == 1 && hit == true) ||  (timing.condition == 2 && hit == false))
            {
                if(timing.se.name != "")
                {
                    AudioFile se = timing.se;
                    Audio.se_play("Audio/SE/" + se.name, se.volume, se.pitch);
                }

                switch(timing.flash_scope)
                {
                    case 1:
                        this.flash(timing.flash_color, timing.flash_duration * 2);
                        break;
                    case 2:
                        if(this.viewport != null)
                        {
                            this.viewport.flash(timing.flash_color, timing.flash_duration * 2);
                        }
                        break;
                    case 3:
                        this.flash(null, timing.flash_duration * 2);
                        break;
                }
            }
        }

        public override int x
        {
            get
            {
                return base.x;
            }
            set
            {
                int sx = value - this.x;
                if(sx != 0)
                {
                    if(this._animation_sprites != null)
                    {
                        for(int i=0; i<16; i++)
                        {
                            ((RGSS.Sprite)this._animation_sprites[i]).x += sx;
                        }
                    }

                    if(this._loop_animation_sprites != null)
                    {
                        for(int i=0; i<16; i++)
                        {
                            ((RGSS.Sprite)this._loop_animation_sprites[i]).x += sx;
                        }
                    }
                }

                base.x = value;
            }
        }

        public override int y
        {
            get
            {
                return base.y;
            }
            set
            {
                int sy = y - this.y;
                if(sy != 0)
                {
                    if(this._animation_sprites != null)
                    {
                        for(int i=0; i<16; i++)
                        {
                            ((RGSS.Sprite)this._animation_sprites[i]).y += sy;
                        }
                    }

                    if(this._loop_animation_sprites != null)
                    {
                        for(int i=0; i<16; i++)
                        {
                            ((RGSS.Sprite)this._loop_animation_sprites[i]).y += sy;
                        }
                    }
                }

                base.y = value;
            }
        }
    }
}
